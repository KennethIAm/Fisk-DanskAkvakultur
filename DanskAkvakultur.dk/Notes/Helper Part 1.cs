using DanskAkvakultur.dk.Shared.Models.Abstractions;

/// <summary>
/// Represents a generic <see cref="ScoreModel"/>.
/// </summary>
public interface IScore : IAggregateRoot
{
    /// <summary>
    /// Gets the unique client id. Represented as a 128-bit integer.
    /// </summary>
    Guid ClientId { get; }

    /// <summary>
    /// Gets the score acquired by the client.
    /// </summary>
    decimal Score { get; }

    /// <summary>
    /// Gets the date of which the score was created.
    /// </summary>
    DateTime ScoreRegistered { get; }
}