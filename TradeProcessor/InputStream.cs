using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeProcessor
{
    public class InputStream
    {
        private Stream stream;

        public List<string> DataConversion()
        {
            var lines = new List<string>();
            using (var reader = new System.IO.StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}
