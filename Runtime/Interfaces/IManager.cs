/// <summary>
/// Unity Patterns namespace
/// </summary>
namespace UnityPatterns
{
    /// <summary>
    /// An interface that represents a manager
    /// </summary>
    public interface IManager : IController
    {
        /// <summary>
        /// Is not destroying on load
        /// </summary>
        bool IsNotDestroyingOnLoad { get; set; }
    }
}
