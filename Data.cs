using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources_Department
{
    public abstract class DATA
    {
        public abstract void Check();
    }
    public class Employee : DATA
    {
        public Employee(string name, string surname, string lastname, string department, string position, string employment_date)
        {
            this.name = name;
            this.surname = surname;
            this.lastname = lastname;
            this.department = department;
            this.position = position;
            this.employment_date = employment_date;
        
        }
        public string name { get; set; }
        public string surname { get; set; }
        public string lastname { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public string employment_date { get; set; }

        public override void Check() 
        {
            if (string.IsNullOrEmpty(name)) name = "-";
            if (string.IsNullOrEmpty(surname)) surname = "-";
            if (string.IsNullOrEmpty(lastname)) lastname = "-";
            if (string.IsNullOrEmpty(department)) department = "-";
            if (string.IsNullOrEmpty(position)) position = "-";
            if (string.IsNullOrEmpty(employment_date)) employment_date = "-";
        }
    }
    public class FamilyMember : DATA
    {
        public FamilyMember(string status, string pib, int year)
        {
            this.status = status;
            this.pib = pib;
            this.year = year;
        }
        public FamilyMember(FamilyMember member)
        {
            this.status = member.status;
            this.pib = member.pib;
            this.year = member.year;
        }
        public FamilyMember(object obj)
        {
            FamilyMember member = obj as FamilyMember;
            if (member != null)
            {
                this.status = member.status;
                this.pib = member.pib;
                this.year = member.year;
            }
        }

        public string status { get; set; }
        public string pib { get; set; }
        public int year { get; set; }
        public override void Check()
        {
            if (string.IsNullOrEmpty(status)) status = "-";
            if (string.IsNullOrEmpty(pib)) pib = "-";
        }
    }
    public class MilitaryData : DATA
    {
        public MilitaryData(string group,string category,string staff,string rank,string number,string suitability,string officePassport,string officeReal)
        {
            this.Group = group;
            this.Category = category;
            this.Staff = staff;
            this.Rank = rank;
            this.Number = number;
            this.Suitability = suitability;
            this.OfficePassport = officePassport;
            this.OfficeReal = officeReal;
        }
        public MilitaryData(MilitaryData data)
        {
            this.Group = data.Group;
            this.Category = data.Category;
            this.Staff = data.Staff;
            this.Rank = data.Rank;
            this.Number = data.Number;
            this.Suitability = data.Suitability;
            this.OfficePassport = data.OfficePassport;
            this.OfficeReal = data.OfficeReal;
        }
        public MilitaryData(object obj)
        {
            MilitaryData data = obj as MilitaryData;
            if(data != null)
            {
                this.Group = data.Group;
                this.Category = data.Category;
                this.Staff = data.Staff;
                this.Rank = data.Rank;
                this.Number = data.Number;
                this.Suitability = data.Suitability;
                this.OfficePassport = data.OfficePassport;
                this.OfficeReal = data.OfficeReal;
            }
        }
        public MilitaryData()
        {

        }

        public string Group { get; set; }
        public string Category { get; set; }
        public string Staff { get; set; }
        public string Rank { get; set; }
        public string Number { get; set; }
        public string Suitability { get; set; }
        public string OfficePassport { get; set; }
        public string OfficeReal { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Group)) Group = "-";
            if (string.IsNullOrEmpty(Category)) Category = "-";
            if (string.IsNullOrEmpty(Staff)) Staff = "-";
            if (string.IsNullOrEmpty(Rank)) Rank = "-";
            if (string.IsNullOrEmpty(Number)) Number = "-";
            if (string.IsNullOrEmpty(Suitability)) Suitability = "-";
            if (string.IsNullOrEmpty(OfficePassport)) OfficePassport = "-";
            if (string.IsNullOrEmpty(OfficeReal)) OfficeReal = "-";
        }
    }
    public class EducationData : DATA
    {
        public EducationData(string uName, string dName, int year)
        {
            this.UniversityName = uName;
            this.DiplomaName = dName;
            this.Year = year;
        }
        public EducationData(EducationData data)
        {
            this.UniversityName = data.UniversityName;
            this.DiplomaName = data.UniversityName;
            this.Year = data.Year;
        }
        public EducationData(object obj)
        {
            EducationData data = obj as EducationData;
            if(data != null)
            {
                this.UniversityName = data.UniversityName;
                this.DiplomaName = data.UniversityName;
                this.Year = data.Year;
            }
        }
        public string UniversityName { get; set; }
        public string DiplomaName { get; set; }
        public int Year { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(UniversityName)) UniversityName = "-";
            if (string.IsNullOrEmpty(DiplomaName)) DiplomaName = "-";
        }
    }
    public class ProfessionData : DATA
    {
        public ProfessionData(string profession, string qualification, string studyForm)
        {
            this.Profession = profession;
            this.Qualification = qualification;
            this.StudyForm = studyForm;
        }
        public ProfessionData(ProfessionData data)
        {
            this.Profession = data.Profession;
            this.Qualification = data.Qualification;
            this.StudyForm = data.StudyForm;
        }
        public ProfessionData(Object obj)
        {
            ProfessionData data = obj as ProfessionData;
            if(data != null)
            {
                this.Profession = data.Profession;
                this.Qualification = data.Qualification;
                this.StudyForm = data.StudyForm;
            }
        }
        public string Profession { get; set; }
        public string Qualification { get; set; }
        public string StudyForm { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Profession)) Profession = "-";
            if (string.IsNullOrEmpty(Qualification)) Qualification = "-";
            if (string.IsNullOrEmpty(StudyForm)) StudyForm = "-";
        }
    }
    public class AppointmentData : DATA
    {

        public AppointmentData(string Date, string Department, string Position, string Code, decimal Salary, string Reason)
        {
            this.Date = Date;
            this.Department = Department;
            this.Position = Position;
            this.Code = Code;
            this.Salary = Salary;
            this.Reason = Reason;
        }
        public AppointmentData(AppointmentData Data)
        {
            this.Date = Data.Date;
            this.Department = Data.Department;
            this.Position = Data.Position;
            this.Code = Data.Code;
            this.Salary = Data.Salary;
            this.Reason = Data.Reason;
        }
        public AppointmentData(Object obj)
        {
            AppointmentData Data = obj as AppointmentData;
            if(Data != null)
            {
                this.Date = Data.Date;
                this.Department = Data.Department;
                this.Position = Data.Position;
                this.Code = Data.Code;
                this.Salary = Data.Salary;
                this.Reason = Data.Reason;
            }
        }
        public AppointmentData()
        {

        }

        public string Date { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Code { get; set; }
        public decimal Salary { get; set; }
        public string Reason { get; set; }

        public override void Check()
        {
            if (string.IsNullOrEmpty(Date)) Date = DateTime.Today.ToShortDateString();
            if (string.IsNullOrEmpty(Department)) Department = "-";
            if (string.IsNullOrEmpty(Position)) Position = "-";
            if (string.IsNullOrEmpty(Code)) Code = "-";
            if (string.IsNullOrEmpty(Reason)) Reason = "-";
        }
    }
}
