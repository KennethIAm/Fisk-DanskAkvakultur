using System;

namespace DanskAkvakultur.dk.DataAccess.Repositories.ORM
{
    /// <summary>
    /// This class is an ORM, used to map entitie(s) from a data source with a one-to-one relationship.
    /// </summary>
    public class DisplayAnimalInformationView
    {
        public string AnimalName { get; set; }
        public string AnimalType { get; set; }
        public string BriefDescription { get; set; }
        public string HabitatDescription { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
