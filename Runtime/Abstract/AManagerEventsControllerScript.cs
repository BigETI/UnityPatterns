using UnityPatterns.Managers;

/// <summary>
/// Unity Patterns controllers namespace
/// </summary>
namespace UnityPatterns.Controllers
{
    /// <summary>
    /// An abstract class that describes a manager events controller script
    /// </summary>
    /// <typeparam name="TManagerScript">Manager script type</typeparam>
    public abstract class AManagerEventsControllerScript<TManagerScript> :
        AControllerScript,
        IManagerEventsController<TManagerScript>
        where TManagerScript : AManagerScript<TManagerScript>
    {
        /// <summary>
        /// Manager
        /// </summary>
        private TManagerScript manager;

        /// <summary>
        /// Manager
        /// </summary>
        public TManagerScript Manager
        {
            get => manager;
            set
            {
                if (!manager && value)
                {
                    manager = value;
                    RegisterManagerEvents(manager);
                }
            }
        }

        /// <summary>
        /// Registers manager events
        /// </summary>
        /// <param name="manager">Manager</param>
        protected abstract void RegisterManagerEvents(TManagerScript manager);

        /// <summary>
        /// Unregisters manager events
        /// </summary>
        /// <param name="manager">Manager</param>
        protected abstract void UnregisterManagerEvents(TManagerScript manager);

        /// <summary>
        /// Registers manager events (internal)
        /// </summary>
        private void RegisterManagerEventsInternal()
        {
            if (!manager && AManagerScript<TManagerScript>.Instance)
            {
                manager = AManagerScript<TManagerScript>.Instance;
                RegisterManagerEvents(manager);
            }
        }

        /// <summary>
        /// Unregisters manager events (internal)
        /// </summary>
        private void UnregisterManagerEventsInternal()
        {
            if (manager)
            {
                UnregisterManagerEvents(manager);
                manager = null;
            }
        }

        /// <summary>
        /// Used to invoke when script has been awaken
        /// </summary>
        protected virtual void Awake() => RegisterManagerEventsInternal();

        /// <summary>
        /// Gets invoked when script gets destroyed
        /// </summary>
        protected virtual void OnDestroy() => UnregisterManagerEventsInternal();

        /// <summary>
        /// Gets invoked when  script gets enabled
        /// </summary>
        protected virtual void OnEnable() => RegisterManagerEventsInternal();

        /// <summary>
        /// Gets invoked when script gets disabled
        /// </summary>
        protected virtual void OnDisable() => UnregisterManagerEventsInternal();

        /// <summary>
        /// Gets invoked when script has been started
        /// </summary>
        protected virtual void Start() => RegisterManagerEventsInternal();
    }
}
