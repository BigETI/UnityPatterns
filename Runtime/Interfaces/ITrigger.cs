/// <summary>
/// Unity Patterns namespace
/// </summary>
namespace UnityPatterns
{
    /// <summary>
    /// An interface that represents a trigger
    /// </summary>
    public interface ITrigger : IController
    {
        /// <summary>
        /// Destroying trigger when?
        /// </summary>
        EDestroyingTriggerWhen DestroyingTriggerWhen { get; set; }

        /// <summary>
        /// Is destroying entire game object
        /// </summary>
        bool IsDestroyingEntireGameObject { get; set; }

        /// <summary>
        /// Destruction time
        /// </summary>
        float DestructionTime { get; set; }

        /// <summary>
        /// Is destroyed
        /// </summary>
        bool IsDetroyed { get; }
    }
}
