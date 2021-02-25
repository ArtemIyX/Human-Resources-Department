using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources_Department
{
    public class Employee
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
    }
}
