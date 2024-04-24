using System.Collections.Generic;
namespace Repository; 

    public class DeveloperRepo
    {
        private List<Developer> _developers = new List<Developer>();
        private static int _nextDeveloperId = 1;

        // Create
        public void AddDeveloper(Developer developer)
        {
            developer.DeveloperId = _nextDeveloperId++;
            _developers.Add(developer);
        }

        // Read
        public List<Developer> GetAllDevelopers()
        {
            return _developers;
        }

        public Developer GetDeveloperById(int id)
        {
            return _developers.Find(dev => dev.DeveloperId == id);
        }

        // Update
        public void UpdateDeveloper(Developer updatedDeveloper)
        {
            int index = _developers.FindIndex(dev => dev.DeveloperId == updatedDeveloper.DeveloperId);
            if (index != -1)
            {
                _developers[index] = updatedDeveloper;
            }
        }

        // Delete
        public void RemoveDeveloper(int id)
        {
            _developers.RemoveAll(dev => dev.DeveloperId == id);
        }
    }



