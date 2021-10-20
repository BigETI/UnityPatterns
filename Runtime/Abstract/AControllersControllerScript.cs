using System.Collections.Generic;

/// <summary>
/// Unity Patterns controllers namespace
/// </summary>
namespace UnityPatterns.Controllers
{
    /// <summary>
    /// An abstract class that describes a controllers controller script
    /// </summary>
    /// <typeparam name="T">Own type</typeparam>
    public class AControllersControllerScript<T> : AControllerScript where T : AControllersControllerScript<T>
    {
        /// <summary>
        /// Controllers
        /// </summary>
        private static readonly List<T> controllers = new List<T>();

        /// <summary>
        /// Enabled controllers
        /// </summary>
        private static readonly List<T> enabledControllers = new List<T>();

        /// <summary>
        /// Controllers
        /// </summary>
        public static IReadOnlyList<T> Controllers => controllers;

        /// <summary>
        /// Enabled controllers
        /// </summary>
        public static IReadOnlyList<T> EnabledControllers => enabledControllers;

        /// <summary>
        /// Gets invoked when script has been initialized
        /// </summary>
        protected virtual void Awake() => controllers.Add((T)this);

        /// <summary>
        /// Gets invoked when script has been destroyed
        /// </summary>
        protected virtual void OnDestroy() => controllers.Remove((T)this);

        /// <summary>
        /// Gets invoked when script has been enabled
        /// </summary>
        protected virtual void OnEnable() => enabledControllers.Add((T)this);

        /// <summary>
        /// Gets invoked when script has been disabled
        /// </summary>
        protected virtual void OnDisable() => enabledControllers.Remove((T)this);
    }
}
