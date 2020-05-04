using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentHelperLib
{
    /// <summary>
    /// Adding New Patients
    /// </summary>
    public class AddNewPatientData : IAddNewPatientData
    {
        List<Patient> PatientData ;
        public AddNewPatientData(List<Patient> patientsData)
        {
            this.PatientData = patientsData;
        }
        public void AddPatient(string Name,string MRN)
        {
            Patient patient = new Patient();
            patient.Name = Name;
            patient.MRN = MRN;
            PatientData.Add(patient);
        }
        public List<Patient> GetPatients()
        {
            return this.PatientData;
        }
    }
}
