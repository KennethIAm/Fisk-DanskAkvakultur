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
