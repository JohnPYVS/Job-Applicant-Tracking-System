using System;
using System.Collections.Generic;

namespace Job_Applicant_Tracking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Job Applicant Tracking System ====");
        }
    }
    public class IntakeRecords
    {

        public string RecordId;
        public string FirstName;
        public string LastName;
        public string Email;
        public string PhoneNumber;
        public string Address;
        public string City;
        public string State;
        public string PositionApplied;
        public string Notes;

        public int Age;
        public int ApplicationsSubmiited;
        public int DesiredHoursPerWeek;
        public double YearsExperience;

        public bool HasDegree;
        public bool HasCertification;
        public bool WillReocate;
        public bool IsVeteran;
        public bool BackgroundCheckPassed;
        public bool PassedPhoneScreen;

        public string EducationLevel;
        public string EmploymentType;
        public string WorkAuthorization;

        public DateTime AppliedDate;
        public DateTime AvailableStartDate;

        public bool IsQualified;

        // Constructor
        public IntakeRecords(
            string recordId,
            string firstName,
            string lastName,
            string email,
            string phone,
            string addressLine,
            string city,
            string state,
            string positionApplied,
            string notes,
            int age,
            int applicationsSubmitted,
            int desiredHoursPerWeek,
            double yearsExpereience,
            bool hasDegree,
            bool hasCertification,
            bool willRelocate,
            bool isVeteran,
            bool backgroundCheckPassed,
            bool passedPhoneScreen,
            string educationLevel,
            string employmentType,
            string workAuthorization,
            DateTime appliedDate,
            DateTime availableStartDate
        )
        {   
            RecordId = recordId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phone;
            Address = addressLine;
            City = city;
            State = state;
            PositionApplied = positionApplied;
            Notes = notes;

            Age = age;
            ApplicationsSubmiited = applicationsSubmitted;
            DesiredHoursPerWeek = desiredHoursPerWeek;
            YearsExperience = yearsExpereience;

            HasDegree = hasDegree;
            HasCertification = hasCertification;
            IsVeteran = isVeteran;
            BackgroundCheckPassed = backgroundCheckPassed;
            PassedPhoneScreen = passedPhoneScreen;

            EducationLevel = educationLevel;
            EmploymentType = employmentType;
            WorkAuthorization = workAuthorization;

            AppliedDate = appliedDate;
            AvailableStartDate = availableStartDate;

        }
        // Instance 1
        public void CalculateQualification()
        {
            bool bachelorOrHigher = false;

            if(EducationLevel == "Bachelor" || EducationLevel == "Master" || EducationLevel == "PhD")
            {
                bachelorOrHigher = true;
            }
           
      
            if (!PassedPhoneScreen || !BackgroundCheckPassed)
            {
                IsQualified = false;
            }
            else if (bachelorOrHigher && YearsExperience >= 1.0)
            {
                IsQualified = true;
            }
            else if (HasCertification && YearsExperience >= 2.0)
            {
                IsQualified = true;
            }
            else if (IsVeteran && YearsExperience >= 0.5)
            {
                IsQualified = true;
            }
            // For everyone else
            else
            {
                IsQualified = false;
            }
                
            
        }
        // Instance 2
        public string GettFullName()
        {
            return FirstName + " " + LastName;      
        }

    
        
    }
}
