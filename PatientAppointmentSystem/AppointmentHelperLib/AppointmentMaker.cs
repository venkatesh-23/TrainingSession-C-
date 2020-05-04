using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentHelperLib
{
    public class AppointmentMaker : IAppointmentMaker
    {
        public List<PatientAppointment> patientAppointments ;
        EmailSender emailsender = new EmailSender();
        SMSDeliveryManager sms = new SMSDeliveryManager(); 
        public AppointmentMaker(List<PatientAppointment> PatientAppointment)
        {
            this.patientAppointments = PatientAppointment;
        }
        public void MakeAppointment(Patient patient,Department  department,string docName,DateTime dateTime)
        {
            PatientAppointment patientAppointment = new PatientAppointment();
            patientAppointment.patient = patient;
            patientAppointment.department = department;
            patientAppointment.DateTime = dateTime;
            patientAppointment.doctorName = docName;
            patientAppointments.Add(patientAppointment);
            emailsender.SendEmail();
            sms.SendSMS();

        }

        public List<PatientAppointment> GetData()
        {
            return this.patientAppointments;
        }
    }
}
