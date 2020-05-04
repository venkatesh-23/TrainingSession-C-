using System;
using System.Collections.Generic;

namespace AppointmentHelperLib
{
    public interface IAppointmentMaker
    {
        List<PatientAppointment> GetData();
        void MakeAppointment(Patient patient, Department department,string doctorName, DateTime dateTime);
    }
}