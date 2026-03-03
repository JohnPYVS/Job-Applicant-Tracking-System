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
                        SearchApplicants(records);
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

        static void AddNewApplicant(List<IntakeApplicant> records)
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

            int age = ReadIntInRange("Age (18-80): ", 18, 80);
            int applicationSubmitted = ReadIntInRange("Applications Submitted (0-100): ", 0, 100);
            int desiredHours = ReadIntInRange("Desired Hours per week (1-80): ", 1, 80);

            double yearsExperience = ReadDoubleMin("Years of Experience (0+): ", 0.0);
            double expectedSalary = ReadDoubleMin("Expected Salary (0+): ", 0.0);
            double ratingScore = ReadDoubleInRange("Rating Score (0-5): ", 0.0, 5.0);

            bool hasDegree = ReadYesNo("Has a degree> (y/n): ");
            bool hasCertificate = ReadYesNo("Has a certification? (y/n): ");
            bool isVeteran = ReadYesNo("Veteran? (y/n): ");
            bool backgroundCheckPassed = ReadYesNo("Background check passed? (y/n): ");
            bool phoneScreenPassed = ReadYesNo("Phone screen passed? (y/n): ");

            string educationLevel = ReadEducationLevel();
            string employmentType = ReadEmploymentType();
            string workAuth = ReadWorkAuthorization();

            DateTime appliedDate = ReadDateWithTryCatch("Applied date (yyyy-MM-dd): ");
            DateTime availableStartDate = ReadDateWithTryCatch("Available start date: ");


            IntakeApplicant rec = new IntakeApplicant(
            recordId, firstName, lastName, email, phone, address,
            city, state, position, notes, age, applicationSubmitted,
            desiredHours, yearsExperience, ratingScore,
            hasDegree, hasCertificate, isVeteran, backgroundCheckPassed, phoneScreenPassed,
            educationLevel, employmentType, workAuth, appliedDate, availableStartDate);            
            
            records.Add(rec);
            Console.WriteLine("Applicant Record added successfully.");
        }
        
        static void ViewAllApplicants(List<IntakeApplicant> records)
        {
            Console.WriteLine();
            Console.WriteLine("==== View All Applicants ====");

            if (records.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            foreach (IntakeApplicant rec in records)
            {
                rec.Display();
            }
        }

        static void SearchApplicants(List<IntakeApplicant> records)
        {
            Console.WriteLine();
            Console.WriteLine("==== Search Applicants ====");
            if (records.Count == 0)
            {
                Console.WriteLine("No applicants to search.");
                return;
            }

            string keyword = ReadNonEmptyString("Enter a name, email, record ID, or position keyword: ");
            int matches = 0;

            foreach (IntakeApplicant rec in records)
            {
                if (ContainsIgnoreCase(rec.RecordId, keyword) ||
                    ContainsIgnoreCase(rec.FirstName, keyword) ||
                    ContainsIgnoreCase(rec.LastName, keyword) ||
                    ContainsIgnoreCase(rec.Email, keyword) ||
                    ContainsIgnoreCase(rec.PositionApplied, keyword))
                {
                    matches++;
                    rec.Display();
                }
            }

            if (matches == 0)
            {
                Console.WriteLine("Matches found: " + matches);
            }
        }
        static void DisplayApplicantSummary(List<IntakeApplicant> records)
        {
            Console.WriteLine();
            Console.WriteLine("==== Applicant Summary ====");

            if (records.Count == 0)
            {
                Console.WriteLine("No records available.");
                return;
            }

            double totalSalary = 0.0;
            double highestRating = -1.0;
            string bestRatingName = "";
            int qualifiedCount = 0;

            for (int i = 0; i < records.Count; i++)
            {
                IntakeApplicant r = records[i];

                r.CalculateQualification();

                totalSalary += r.ExpectedSalary;

                if (r.RatingScore > highestRating)
                {
                    highestRating = r.RatingScore;
                    bestRatingName = r.GettFullName();
                }
                if (r.IsQualified)
                {
                    qualifiedCount++;
                }
            }

            double avgSalary = totalSalary / records.Count;
            double qualifiedPercent = (qualifiedCount * 100.0) / records.Count;

            Console.WriteLine("Total Records: " + records.Count);
            Console.WriteLine("Average Expected Salary: " + avgSalary.ToString("0.00"));
            Console.WriteLine("Highest Rating Score: " + highestRating.ToString("0.00") + 
                " (" + bestRatingName + ")");
            Console.WriteLine("Qualified Applicants: " + qualifiedCount +
                " (" + qualifiedPercent.ToString("0.00") + "%)");
        }

        static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();

                if (s != null)
                {
                    s = s.Trim();
                }
                if (!string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("Input cannot be empty.");
                }
            }
        }
       static int ReadIntInRange(string prompt, int min, int max)
       {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                int value;
                if (int.TryParse(input, out value))
                {
                    if (value >= min && value <= max)
                    {
                       return value;
                    }
                }
                    Console.WriteLine("Enter a whole number between " + min + " and " + max + ".");
            }
           
        
       }
            static double ReadDoubleMin(string prompt, double min)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    double value;
                    if (double.TryParse(input, out value))
                    {
                        if (value >= min)
                        {
                            return value;
                        }
                    }
                    Console.WriteLine("Enter a number greater than or equal to " + min + ".");
                }
            }
            static double ReadDoubleInRange(string prompt, double min, double max)
            {
             while (true)
             {
                Console.Write(prompt);
                string input = Console.ReadLine();

                double value;
                if (double.TryParse(input, out value))
                {
                    if (value >= min)
                    {
                        return value;
                    }
                }
                Console.WriteLine("Enter a number greater than or equal to " + max + ".");
             }  
            }
            static bool ReadYesNo(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (input == null) input = "";
                    input = input.Trim().ToLower();

                    if (input == "y" || input == "yes") return true;
                    if (input == "n" || input == "no") return false;
                    Console.WriteLine("Enter y/n");
                                                     
                }
            }
            static string ReadEducationLevel()
            {
                Console.WriteLine("EducationLevel:");
                Console.WriteLine("1. High School");
                Console.WriteLine("2. Associate");
                Console.WriteLine("3. Bachelor");
                Console.WriteLine("4. Master");
                Console.WriteLine("5. PhD");
                int choice = ReadIntInRange("Select 1-5: ", 1, 5);
                
                switch (choice)
                {
                    case 1: return "High School";
                    case 2: return "Associate";
                    case 3: return "Bachelor";
                    case 4: return "Master";
                    case 5: return "PhD";
                    default: return "High School";
                }

            
            }
            static string ReadEmploymentType()
            {
                Console.WriteLine("Employment Type:");
                Console.WriteLine("1. Full-Time");
                Console.WriteLine("2. Part-Time");
                Console.WriteLine("3. Contract");
                int choice = ReadIntInRange("Select 1-3: ", 1, 3);

                switch (choice)
                {
                    case 1: return "Full-Time";
                    case 2: return "Part-Time";
                    case 3: return "Contract";
                    default: return "Full-Time";
                }

            }
            static string ReadWorkAuthorization()
            {
                Console.WriteLine("Work Authorization:");
                Console.WriteLine("1. Citizen");
                Console.WriteLine("2. Permanent Resident");
                Console.WriteLine("3. Visa");
                int choice = ReadIntInRange("Select 1-3: ", 1, 3);
                
                switch (choice)
                {
                case 1: return "Citizen";
                case 2: return "Permanent Resident";
                case 3: return "Visa";
                default: return "Citizen"; 
                } 


            }
            static DateTime ReadDateWithTryCatch(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    try
                    {
                        DateTime dt = DateTime.Parse(input);
                        return dt.Date;
                    }
                    catch (Exception)
                    {
                    Console.WriteLine("Invalid date. Please use (yyyy-MM-dd) as an example");
                    }
                }
            }
            static bool ContainsIgnoreCase(string source, string keyword)
            {
                if (source == null) source = "";
                if (keyword == null) keyword = "";

                source = source.ToLower();
                keyword = keyword.ToLower();
                return source.Contains(keyword);
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
                records.Add(new IntakeApplicant(
                    "AA-W0001", "John", "Doe", "johndoe@example.com", "559-1010",
                    "17 Ace St", "Anaheim", "CA", "Junior Developer", "Strong Project",
                    20, 2, 40,
                    1, 70000, 4.6,
                    true, false, false, true, true,
                    "Bachelor", "Full-Time", "Citizen",
                    new DateTime(2026, 03, 3), new DateTime(2026, 03, 13)
                ));

                records.Add(new IntakeApplicant(
                    "AA-W0002", "Brandon", "Blades", "brandonblades@example.com", "559-2021" +
                    "5th Ave", "New York City", "IT", "Very motivated in learning new stuff",
                    23, 3, 50,
                    3, 80000, 4.6,
                    true, true, false, true, true,
                    "Master", "Fulltime", "Visa",
                    new DateTime(2026, 03, 1), new DateTime(2026, 04, 2)
                ));

                records.Add(new IntakeApplicant(
                    "AA-W0003", "Henry", "Park", "henrypark@example.com", "559-0234",
                    "1234 Maple Ave", "Michigan", "Senior Developer", "Leadership, Detail oriented, and Strong Projects",
                    34, 10, 70,
                    10, 150000, 5.0,
                    true, true, true, true, true,
                    "PhD", "Contract", "Permanent Resident",
                    new DateTime(2026, 03, 10), new DateTime(2026, 04, 5)
                ));

                   
                    
                    
            }
           
            
          
    }
}
