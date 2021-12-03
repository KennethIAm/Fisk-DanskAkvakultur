using System;

namespace DanskAkvakultur.dk.DataAccess.Repositories.ORM
{
    public class DisplayAnimalInformationView
    {
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public string BriefDescription { get; set; }
        public string HabitatDescription { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
