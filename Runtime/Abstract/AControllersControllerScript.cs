using System.Collections.Generic;

/// <summary>
/// Unity Patterns controllers namespace
/// </summary>
namespace UnityPatterns.Controllers
{
    /// <summary>
    /// An abstract class that describes a controllers controller script
    /// </summary>
    /// <typeparam name="TControllersControllerScript">Controllers controller script type</typeparam>
    public abstract class AControllersControllerScript<TControllersControllerScript> :
        AControllerScript
        where TControllersControllerScript : AControllersControllerScript<TControllersControllerScript>
    {
        /// <summary>
        /// Controllers
        /// </summary>
        private static readonly List<TControllersControllerScript> controllers = new List<TControllersControllerScript>();

        /// <summary>
        /// Enabled controllers
        /// </summary>
        private static readonly List<TControllersControllerScript> enabledControllers = new List<TControllersControllerScript>();

        /// <summary>
        /// Controllers
        /// </summary>
        public static IReadOnlyList<TControllersControllerScript> Controllers => controllers;

        /// <summary>
        /// Enabled controllers
        /// </summary>
        public static IReadOnlyList<TControllersControllerScript> EnabledControllers => enabledControllers;

        /// <summary>
        /// Gets invoked when script has been initialized
        /// </summary>
        protected virtual void Awake() => controllers.Add((TControllersControllerScript)this);

        /// <summary>
        /// Gets invoked when script has been destroyed
        /// </summary>
        protected virtual void OnDestroy() => controllers.Remove((TControllersControllerScript)this);

        /// <summary>
        /// Gets invoked when script has been enabled
        /// </summary>
        protected virtual void OnEnable() => enabledControllers.Add((TControllersControllerScript)this);

        /// <summary>
        /// Gets invoked when script has been disabled
        /// </summary>
        protected virtual void OnDisable() => enabledControllers.Remove((TControllersControllerScript)this);
    }
}
