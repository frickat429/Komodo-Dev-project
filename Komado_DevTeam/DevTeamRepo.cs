namespace Repository 
{
        public class DevTeamRepo
    {
        private List<DevTeam> _teams = new List<DevTeam>();
        private static int _nextTeamId = 1; 

        public DevTeamRepo () 
        {
            SeedTeams () ;
        } 

        private void SeedTeams() 
        {
            AddTeam(new DevTeam{TeamName = "Male training", TeamMembers = new List<Developer>()}) ;
            AddTeam(new DevTeam{TeamName = "Female training", TeamMembers = new List<Developer>()}) ;
        }

        // Create
        public void AddTeam(DevTeam team)
        {
            team.TeamId = _nextTeamId++;
            _teams.Add(team);
        }

        // Read
        public List<DevTeam> GetAllTeams()
        {
            return _teams;
        }

        public DevTeam GetTeamById(int id)
        {
            return _teams.Find(team => team.TeamId == id);
        }

        // Delete
        public void RemoveTeam(int id)
        {
            _teams.RemoveAll(team => team.TeamId == id);
        }

        // Other methods
        public void AddDeveloperToTeam(int teamId, Developer developer)
        {
            DevTeam team = _teams.Find(t => t.TeamId == teamId);
            if (team != null)
            {
                team.TeamMembers.Add(developer);
            }
        }

        public void RemoveDeveloperFromTeam(int teamId, int developerId)
        {
            DevTeam team = _teams.Find(t => t.TeamId == teamId);
            if (team != null)
            {
                team.TeamMembers.RemoveAll(dev => dev.DeveloperId == developerId);
            }
        }
    }
}
