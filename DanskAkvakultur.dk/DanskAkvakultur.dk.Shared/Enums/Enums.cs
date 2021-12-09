namespace DanskAkvakultur.dk.Shared.Enums
{
    /// <summary>
    /// Used to enable different types of credentials when connecting to a database.
    /// </summary>
    public enum DbCredentialType
    {
        BASIC_READ,
        COMPLEX_READ,
        CREATE_PERMISSION,
        UPDATE_PERMISSION,
        DELETE_PERMISSION
    }
}
