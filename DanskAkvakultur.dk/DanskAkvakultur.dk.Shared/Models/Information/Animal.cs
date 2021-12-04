namespace DanskAkvakultur.dk.Shared.Models.Information
{
    /// <summary>
    /// Handles the information about a generic animal.
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// Get the name of the animal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get the type of the animal.
        /// </summary>
        public AnimalType AnimalType { get; set; }
    }
}
