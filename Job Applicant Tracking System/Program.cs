using Microsoft.VisualBasic;
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
    public class IntakeApplicant
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
        public int ApplicationsSubmitted;
        public int DesiredHoursPerWeek;
        public double YearsExperience;
        public double ExpectedSalary;
        public double RatingScore;

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
        public IntakeApplicant(
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
            double expectedSalary,
            double ratingScore,
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
            ApplicationsSubmitted = applicationsSubmitted;
            DesiredHoursPerWeek = desiredHoursPerWeek;
            YearsExperience = yearsExpereience;
            ExpectedSalary = expectedSalary;
            RatingScore = ratingScore;

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

            if (EducationLevel == "Bachelor" || EducationLevel == "Master" || EducationLevel == "PhD")
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

        public void CalculateRating()
        {
            double score = 0;

            if (YearsExperience >= 5)
                score += 2;
            else if (YearsExperience >= 2)
                score += 1;

            if (HasDegree)
                score += 1;
            if (HasCertification)
                score += 1;
            if (PassedPhoneScreen)
                score += 1;

            if (score > 5)
                score = 5;

            RatingScore = score;
        }
        public void Display()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Record ID: " + RecordId);
            Console.WriteLine("Name: " + GettFullName());
            Console.WriteLine("Position: " + PositionApplied);
            Console.WriteLine("Email: " + Email + " | Phone: " + PhoneNumber);
            Console.WriteLine("Location: " + Address + ", " + City + ", " + State);
            Console.WriteLine("Applied: " + AppliedDate.ToString("yyyy-MM-dd") +
                              " | Available: " + AvailableStartDate.ToString("yyyyy-MM-dd"));
            Console.WriteLine("Education: " + EducationLevel + " | Employment Type: " + EmploymentType +
                              " | Work Auth:" + WorkAuthorization);
            Console.WriteLine("Age: " + Age + " | Years Exp: " + YearsExperience);
            Console.WriteLine("Expected Salary: " + ExpectedSalary + " | Desired Hours/Week: " + DesiredHoursPerWeek);
            Console.WriteLine("Rating Score: " + RatingScore.ToString("0.00"));
            Console.WriteLine("Has Degree: " + HasDegree + " | Has Certification: " + HasCertification +
                              " | Veteran: " + IsVeteran);
            Console.WriteLine("Phone Screen: " + PassedPhoneScreen + " | Background Check: " + BackgroundCheckPassed);
            Console.WriteLine("ApplicationsSubmitted: " + ApplicationsSubmitted);
            Console.WriteLine("Qualified : " + IsQualified);
            Console.WriteLine("Notes: " + Notes);
            Console.WriteLine("-----------------------------------------");

        }
   
    }

    class ApplicantTrackerApp
    {
        static void Main(string[] args)
        {
            List<IntakeApplicant> records = new List<IntakeApplicant>();

            SeedSampleRecords(records);

            int choice;
            do
            {
                PrintMenu();
                choice = ReadMenuChoice(1, 5);

                switch (choice)
                {
                    case 1:
                        AddNewApplicant(records);
                        break;
                    case 2:
                        ViewAllApplicants(records);
                        break;
                    case 3:
                        SearchRecords(records);
                        break;
                    case 4:
                        DisplayApplicantSummary(records);
                        break;
                    case 5:
                        Console.WriteLine("Exiting Program.");
                        break;
                }
            } while (choice != 5);
        }

        static void AddNewRecord(List<IntakeApplicant> records)
        {
            Console.WriteLine();
            Console.WriteLine("==== Add New Applicant ====");

            string recordId = ReadNonEmptyString("Record ID (ex: AA-W0005");
            string firstName = ReadNonEmptyString("First Name: ");
            string lastName = ReadNonEmptyString("Last Name: ");
            string email = ReadNonEmptyString("Email: ");
            string phone = ReadNonEmptyString("Phone: ");
            string address = ReadNonEmptyString("Address Line: ");
            string city = ReadNonEmptyString("City: ");
            string state = ReadNonEmptyString("State: ");
            string position = ReadNonEmptyString("Position Applied: ");
            string notes = ReadNonEmptyString("Notes: ");

        }
            static void PrintMenu()
            {
                Console.WriteLine();
                Console.WriteLine("1) Add New Applicant");
                Console.WriteLine("2) View All Apllicants");
                Console.WriteLine("3) Search Records");
                Console.WriteLine("4) Display Applicant Summary");
                Console.WriteLine("5) Exit");
                Console.WriteLine("Select an option (1-5): ");
            }
            
            static int ReadMenuChoice(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                int value;
                if (int.TryParse(input, out value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                    else
                    {
                        Console.Write("Invalid choice. Enter a number " + min + "-" + max + ": ");
                    }
                }
                else
                {
                    Console.Write("Invalid input. Enter a number" + min + "-" + max + ": ");
                }
            }
        }
            static void SeedSampleRecords(List<IntakeApplicant> records)
            {
                    
                    
            }
            
          
    }
}
