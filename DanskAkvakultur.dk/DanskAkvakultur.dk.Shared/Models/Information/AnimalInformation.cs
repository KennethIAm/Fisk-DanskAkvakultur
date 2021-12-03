using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
