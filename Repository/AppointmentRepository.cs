using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using hospmanagement.Entities;
using Microsoft.Extensions.Configuration;


namespace hospmanagement.Repository
{
    public class AppointmentRepository : IAppointmentRepository1
    {
    
        private string ConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private SqlCommand cmd = null;

        public string ConnString1 { get => ConnString; set => ConnString = value; }

        public AppointmentRepository()
        {
            cmd = new SqlCommand();
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            Appointment appointment = null;

            using (SqlConnection sqlConnection = new SqlConnection(ConnString1))
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM Appointment WHERE appointmentId = @AppointmentId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        appointment = new Appointment
                        {
                            AppointmentId = (int)reader["appointmentId"],
                            PatientId = (int)reader["patientId"],
                            DoctorId = (int)reader["doctorId"],
                            AppointmentDate = (DateTime)reader["appointmentDate"],
                            Description = (string)reader["description"]
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving appointment by ID: {ex.Message}");
                }
            }

            return appointment;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnString1))
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM Appointment WHERE patientId = @PatientId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointments.Add(new Appointment
                        {
                            AppointmentId = (int)reader["appointmentId"],
                            PatientId = (int)reader["patientId"],
                            DoctorId = (int)reader["doctorId"],
                            AppointmentDate = (DateTime)reader["appointmentDate"],
                            Description = (string)reader["description"]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving appointments for patient: {ex.Message}");
                }
            }

            return appointments;
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnString1))
            {
                try
                {
                    cmd.CommandText = "INSERT INTO Appointment (appointmentId, patientId, doctorId, appointmentDate, description) " +
                                      "VALUES (@AppointmentId, @PatientId, @DoctorId, @AppointmentDate, @Description)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@Description", appointment.Description);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error scheduling appointment: {ex.Message}");
                    return false;
                }
            }
        }

        public bool CancelAppointment(int appointmentId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnString1))
            {
                try
                {
                    cmd.CommandText = "DELETE FROM Appointment WHERE appointmentId = @AppointmentId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error cancelling appointment: {ex.Message}");
                    return false;
                }
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnString1))
            {
                try
                {
                    cmd.CommandText = "UPDATE Appointment SET appointmentDate = @AppointmentDate, description = @Description " +
                                      "WHERE appointmentId = @AppointmentId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    cmd.Parameters.AddWithValue("@Description", appointment.Description);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating appointment: {ex.Message}");
                    return false;
                }
            }
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnString1))
            {
                try
                {
                    cmd.CommandText = "SELECT * FROM Appointment WHERE doctorId = @DoctorId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appointments.Add(new Appointment
                        {
                            AppointmentId = (int)reader["appointmentId"],
                            PatientId = (int)reader["patientId"],
                            DoctorId = (int)reader["doctorId"],
                            AppointmentDate = (DateTime)reader["appointmentDate"],
                            Description = (string)reader["description"]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving appointments for doctor: {ex.Message}");
                }
            }

            return appointments;
        }


    }
}
