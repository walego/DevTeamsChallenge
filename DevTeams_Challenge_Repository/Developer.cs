using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public enum Specialty { FrontEnd = 1, BackEnd, Testing }
    public class Developer
    {
        public Developer() { }
        public Developer(string firstName, string lastName, Specialty specitaly, bool hasPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialty = specitaly;
            PluralsightAccess = hasPluralsight;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DeveloperID { get; set; }
        public Specialty Specialty { get; set; }
        public bool PluralsightAccess { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
