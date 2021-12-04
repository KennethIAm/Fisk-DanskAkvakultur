using System;

namespace DanskAkvakultur.dk.Shared.Models.Information
{
    /// <summary>
    /// Handles the information about an animal.
    /// </summary>
    public class AnimalInformation
    {
        public Animal Animal { get; set; }
        public string BriefDescription { get; set; }
        public string HabitatDescription { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
