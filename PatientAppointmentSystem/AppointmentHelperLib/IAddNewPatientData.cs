using System.Collections.Generic;

namespace AppointmentHelperLib
{
    public interface IAddNewPatientData
    {
        void AddPatient(string Name, string MRN);
        List<Patient> GetPatients();
    }
}