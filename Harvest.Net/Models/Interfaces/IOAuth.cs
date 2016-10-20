namespace Harvest.Net.Models.Interfaces
{
    /// <summary>
    /// Interface for the OAuth response model.
    /// </summary>
    public interface IOAuth
    {
        /// <summary>
        /// Access token given by the API.
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        /// Token to refresh the access token.
        /// </summary>
        string RefreshToken { get; set; }

        /// <summary>
        /// Time left til expiration date of the token.
        /// </summary>
        int? ExpiresIn { get; set; }

        /// <summary>
        /// Type of the token.
        /// Example:
        /// <example>
        /// bearer
        /// </example>
        /// </summary>
        string TokenType { get; set; }
    }
}
