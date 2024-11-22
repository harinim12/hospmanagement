

using System;
using System.Collections.Generic;
using hospmanagement.Entities;
using hospmanagement.Repository;
using hospmanagemnt.Services;

namespace hospmanagement.Services
{
    public class HospitalServiceImpl : IHospitalService
    {
        private readonly IAppointmentRepository1 _appointmentRepository;

        
        public HospitalServiceImpl(IAppointmentRepository1 appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public HospitalServiceImpl()
        {
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _appointmentRepository.GetAppointmentById(appointmentId)
                   ?? throw new Exception("Appointment not found.");
        }

    
        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            var appointments = _appointmentRepository.GetAppointmentsForPatient(patientId);
            if (appointments == null || appointments.Count == 0)
            {
                throw new Exception("No appointments found for the patient.");
            }
            return appointments;
        }

        
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var appointments = _appointmentRepository.GetAppointmentsForDoctor(doctorId);
            if (appointments == null || appointments.Count == 0)
            {
                throw new Exception("No appointments found for the doctor.");
            }
            return appointments;
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null.");

            return _appointmentRepository.ScheduleAppointment(appointment);
        }

       
        public bool UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null.");

            return _appointmentRepository.UpdateAppointment(appointment);
        }

        public bool CancelAppointment(int appointmentId)
        {
            return _appointmentRepository.CancelAppointment(appointmentId);
        }
    }
}
