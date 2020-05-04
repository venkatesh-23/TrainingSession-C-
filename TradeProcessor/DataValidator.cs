using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeProcessor
{
    public class DataValidator
    {
        private static float LotSize = 100000f;
        ConsoleLogger log = new ConsoleLogger();
        List<string> lines = new List<string>();
        public DataValidator(List<string> temp)
        {
            this.lines = temp;
        }
        public List<TradeRecord> Validate()
        {
            var trades = new List<TradeRecord>();

            var lineCount = 1;
            foreach (var line in lines)
            {
                var fields = line.Split(new char[] { ',' });

                if (fields.Length != 3)
                {
                    Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.",
      lineCount, fields.Length);
                    continue;
                }

                if (fields[0].Length != 6)
                {
                    Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'",
      lineCount, fields[0]);
                    continue;
                }

                int tradeAmount;
                if (!int.TryParse(fields[1], out tradeAmount))
                {
                    Console.WriteLine("WARN: Trade amount on line {0} not a valid integer:'{1}'", lineCount, fields[1]);
                }

                decimal tradePrice;
                if (!decimal.TryParse(fields[2], out tradePrice))
                {
                    Console.WriteLine("WARN: Trade price on line {0} not a valid decimal:'{1}'", lineCount, fields[2]);
                }

                var sourceCurrencyCode = fields[0].Substring(0, 3);
                var destinationCurrencyCode = fields[0].Substring(3, 3);

                // calculate values
                var trade = new TradeRecord
                {
                    SourceCurrency = sourceCurrencyCode,
                    DestinationCurrency = destinationCurrencyCode,
                    Lots = tradeAmount / LotSize,
                    Price = tradePrice
                };

                trades.Add(trade);

                lineCount++;
            }
            return trades;
        }
    }
}
