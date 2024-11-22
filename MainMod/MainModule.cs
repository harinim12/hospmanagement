using System;
using System.Collections.Generic;
using hospmanagement.Entities;
using hospmanagement.Repository;
using hospmanagement.Services;

namespace HospManagement.MainMod
{
    public class MainModule
    {
        static void Main(string[] args)
        {
           
            AppointmentRepository appointmentRepository = new AppointmentRepository(); 
            IHospitalService hospitalService = new HospitalServiceImpl(appointmentRepository); 

            int choice;
            do
            {
                // Display menu options
                Console.WriteLine("\n--- Hospital Management System ---");
                Console.WriteLine("1. Schedule a new appointment");
                Console.WriteLine("2. Update an appointment");
                Console.WriteLine("3. Get appointment by ID");
                Console.WriteLine("4. Get appointments for a patient");
                Console.WriteLine("5. Get appointments for a doctor");
                Console.WriteLine("6. Cancel an appointment");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Schedule a new appointment
                        Console.WriteLine("\nScheduling a new appointment...");
                        Appointment newAppointment = new Appointment
                        {
                            AppointmentId = 1,
                            PatientId = 101,
                            DoctorId = 201,
                            AppointmentDate = DateTime.Now.AddDays(1),
                            Description = "Routine check-up"
                        };

                        bool isScheduled = hospitalService.ScheduleAppointment(newAppointment);
                        Console.WriteLine(isScheduled ? "Appointment scheduled successfully." : "Failed to schedule appointment.");
                        break;

                    case 2:
                        // Update an existing appointment
                        Console.WriteLine("\nUpdating appointment...");
                        Appointment updateAppointment = new Appointment
                        {
                            AppointmentId = 1,
                            PatientId = 101,
                            DoctorId = 201,
                            AppointmentDate = DateTime.Now.AddDays(2),
                            Description = "Follow-up visit"
                        };

                        bool isUpdated = hospitalService.UpdateAppointment(updateAppointment);
                        Console.WriteLine(isUpdated ? "Appointment updated successfully." : "Failed to update appointment.");
                        break;

                    case 3:
                        // Get appointment by ID
                        Console.Write("\nEnter Appointment ID to fetch: ");
                        int appointmentId = int.Parse(Console.ReadLine());
                        Appointment fetchedAppointment = hospitalService.GetAppointmentById(appointmentId);

                        if (fetchedAppointment != null)
                        {
                            Console.WriteLine($"Appointment ID: {fetchedAppointment.AppointmentId}, " +
                                              $"Description: {fetchedAppointment.Description}, " +
                                              $"Date: {fetchedAppointment.AppointmentDate}");
                        }
                        else
                        {
                            Console.WriteLine("Appointment not found.");
                        }
                        break;

                    case 4:
                        // Get appointments for a patient
                        Console.Write("\nEnter Patient ID to fetch appointments: ");
                        int patientId = int.Parse(Console.ReadLine());
                        List<Appointment> patientAppointments = hospitalService.GetAppointmentsForPatient(patientId);

                        if (patientAppointments.Count > 0)
                        {
                            foreach (var appointment in patientAppointments)
                            {
                                Console.WriteLine($"Appointment ID: {appointment.AppointmentId}, " +
                                                  $"Doctor ID: {appointment.DoctorId}, " +
                                                  $"Date: {appointment.AppointmentDate}, " +
                                                  $"Description: {appointment.Description}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No appointments found for the patient.");
                        }
                        break;

                    case 5:
                        // Get appointments for a doctor
                        Console.Write("\nEnter Doctor ID to fetch appointments: ");
                        int doctorId = int.Parse(Console.ReadLine());
                        List<Appointment> doctorAppointments = hospitalService.GetAppointmentsForDoctor(doctorId);

                        if (doctorAppointments.Count > 0)
                        {
                            foreach (var appointment in doctorAppointments)
                            {
                                Console.WriteLine($"Appointment ID: {appointment.AppointmentId}, " +
                                                  $"Patient ID: {appointment.PatientId}, " +
                                                  $"Date: {appointment.AppointmentDate}, " +
                                                  $"Description: {appointment.Description}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No appointments found for the doctor.");
                        }
                        break;

                    case 6:
                        // Cancel an appointment
                        Console.Write("\nEnter Appointment ID to cancel: ");
                        int cancelAppointmentId = int.Parse(Console.ReadLine());
                        bool isCanceled = hospitalService.CancelAppointment(cancelAppointmentId);

                        Console.WriteLine(isCanceled ? "Appointment canceled successfully." : "Failed to cancel appointment.");
                        break;

                    case 7:
                        // Exit
                        Console.WriteLine("\nExiting the system...");
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice! Please select a valid option.");
                        break;
                }

            } while (choice != 7); // Loop until the user chooses to exit
        }
    }
}
