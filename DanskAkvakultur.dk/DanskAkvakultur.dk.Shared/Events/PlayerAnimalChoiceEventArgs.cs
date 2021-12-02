using System;

namespace DanskAkvakultur.dk.Shared.Events
{
    /// <summary>
    /// Provides the ability to share data when a player has picked an animal.
    /// </summary>
    public class PlayerAnimalChoiceEventArgs : EventArgs
    {
        public string AnimalName { get; set; }
        public object Information { get; set; }
    }
}
