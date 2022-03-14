using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developers = new List<Developer>();
        private int _id = 100;

        public bool AddDeveloper(Developer developer)
        {
            int startingCount = _developers.Count();
            _id++;
            _developers.Add(developer);
            developer.DeveloperID = _id;
            bool wasAdded = (_developers.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Developer> GetAllDevelopers()
        {
            _developers.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            return _developers;
        }


        public Developer GetDevByID(int id)
        {
            return _developers.Where(d => d.DeveloperID == id).SingleOrDefault();
        }

        public bool UpdateDeveloper(int devID, Developer newDev)
        {
            Developer oldDev = GetDevByID(devID);
            if (oldDev != null)
            {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.PluralsightAccess = newDev.PluralsightAccess;
                oldDev.Specialty = newDev.Specialty;

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDeveloper(Developer developer)
        {
            bool removeResult = _developers.Remove(developer);
            return removeResult;
        }
    }
}
