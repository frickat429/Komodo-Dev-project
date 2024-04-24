using System.Collections.Generic;


namespace Repository ;


    public class DevTeam
    {
        public int TeamId { get; set; } 
        public string TeamName { get; set; } 
        public List<Developer> TeamMembers { get; set; } 
    }
