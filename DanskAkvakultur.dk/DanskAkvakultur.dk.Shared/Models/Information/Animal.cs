using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskAkvakultur.dk.Shared.Models.Information
{
    /// <summary>
    /// Handles the information about a generic animal.
    /// </summary>
    public class Animal
    {
        public string Name { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}
