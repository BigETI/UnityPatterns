/// <summary>
/// Unity Patterns namespace
/// </summary>
namespace UnityPatterns
{
    /// <summary>
    /// An interface that represents a manager events controllers
    /// </summary>
    /// <typeparam name="T">Manager type</typeparam>
    public interface IManagerEventsController<T> : IController where T : IManager
    {
        /// <summary>
        /// Manager
        /// </summary>
        T Manager { get; set; }
    }
}
