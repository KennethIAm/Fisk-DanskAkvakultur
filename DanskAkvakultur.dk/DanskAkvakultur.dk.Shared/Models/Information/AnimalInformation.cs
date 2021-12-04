using System;

namespace DanskAkvakultur.dk.Shared.Models.Information
{
    /// <summary>
    /// Handles the information about an animal.
    /// </summary>
    public class AnimalInformation
    {
        /// <summary>
        /// Get the <see cref="Animal"/> object.
        /// </summary>
        public Animal Animal { get; set; }

        /// <summary>
        /// Get a brief description about the animal.
        /// </summary>
        public string BriefDescription { get; set; }

        /// <summary>
        /// Get a description for the animals habitat.
        /// </summary>
        public string HabitatDescription { get; set; }

        /// <summary>
        /// Get the data of when the data was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}
