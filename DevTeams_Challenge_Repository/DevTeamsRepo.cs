using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Repository
{
    public class DevTeamsRepo : DeveloperRepo
    {
        //This is our Repository class that will hold our directory (which will act as our database) and methods that will directly talk to our directory.
        private List<DevTeam> _devTeams = new List<DevTeam>();
        private int _teamNumber = 0;

        // C
        public bool AddNewTeam(DevTeam devTeam)
        {
            int startingCount = _devTeams.Count();
            _teamNumber++;
            _devTeams.Add(devTeam);
            devTeam.TeamID = _teamNumber;
            bool wasAdded = (_devTeams.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // R
        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeams;
        }

        public DevTeam GetDevTeamByID(int teamID)
        {
            return _devTeams.Where(d => d.TeamID == teamID).SingleOrDefault();
        }
        public DevTeam GetDevTeamByName(string teamName)
        {
            return _devTeams.Where(d => d.TeamName.ToLower() == teamName.ToLower()).SingleOrDefault();
        }

        // U
        public bool UpdateTeamNameByName(string oldName, string newName)
        {
            DevTeam oldTeam = GetDevTeamByName(oldName);
            if (oldTeam != null)
            {
                oldTeam.TeamName = $"{newName}";
                return true;
            }
            else
                return false;
        }
        public bool AddDeveloperToTeam(int devID, int teamID)
        {
            Developer dev = GetDevByID(devID);
            DevTeam dTeam = GetDevTeamByID(teamID);
            if (dev != default && dTeam != default)
            {
                int startingCount = dTeam.Developers.Count();
                dTeam.Developers.Add(dev);
                return dTeam.Developers.Count > startingCount ? true : false;
            }
            else
                return false;
        }

        public bool RemoveDeveloperFromTeam(int devID, int teamID)
        {
            Developer dev = GetDevByID(devID);
            DevTeam dTeam = GetDevTeamByID(teamID);
            if (dev != default && dTeam != default)
            {
                bool wasRemoved = dTeam.Developers.Remove(dev);
                return wasRemoved;
            }
            else
                return false;
        }

        // D
        public bool RemoveDevTeam(DevTeam devTeam)
        {
            bool wasRemoved = _devTeams.Remove(devTeam);
            return wasRemoved;
        }
    }
}
