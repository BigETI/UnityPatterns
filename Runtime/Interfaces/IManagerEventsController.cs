/// <summary>
/// Unity Patterns namespace
/// </summary>
namespace UnityPatterns
{
    /// <summary>
    /// An interface that represents a manager events controllers
    /// </summary>
    /// <typeparam name="TManagerScript">Manager script type</typeparam>
    public interface IManagerEventsController<TManagerScript> : IController where TManagerScript : IManager
    {
        /// <summary>
        /// Manager
        /// </summary>
        TManagerScript Manager { get; set; }
    }
}
