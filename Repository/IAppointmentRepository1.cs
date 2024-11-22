using hospmanagement.Entities;

namespace hospmanagement.Repository
{
    public interface IAppointmentRepository1
    {
        string ConnString1 { get; set; }

        bool CancelAppointment(int appointmentId);
        Appointment GetAppointmentById(int appointmentId);
        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        bool ScheduleAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment);
    }
}