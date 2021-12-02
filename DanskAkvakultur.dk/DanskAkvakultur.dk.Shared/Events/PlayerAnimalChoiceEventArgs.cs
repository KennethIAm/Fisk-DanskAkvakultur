using DanskAkvakultur.dk.Shared.Models.Information;
using System;

namespace DanskAkvakultur.dk.Shared.Events
{
    /// <summary>
    /// Provides the ability to share data when a player has picked an animal.
    /// </summary>
    public class PlayerAnimalChoiceEventArgs : EventArgs
    {
        public AnimalInformation Information { get; set; }
    }
}
