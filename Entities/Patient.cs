﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospmanagement.Entities
{
    public class Patient
    {
       
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

    
        public Patient() { }

        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender, string contactNumber, string address)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            ContactNumber = contactNumber;
            Address = address;
        }

        // Override ToString
        public override string ToString()
        {
            return $"PatientId: {PatientId}, FirstName: {FirstName}, LastName: {LastName}, " +
                   $"DateOfBirth: {DateOfBirth.ToShortDateString()}, Gender: {Gender}, " +
                   $"ContactNumber: {ContactNumber}, Address: {Address}";
        }
    }
}
