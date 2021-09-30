using UnityPatterns.Managers;

/// <summary>
/// Unity Patterns controllers namespace
/// </summary>
namespace UnityPatterns.Controllers
{
    /// <summary>
    /// An abstract class that describes a manager events controller script
    /// </summary>
    /// <typeparam name="T">Manager script type</typeparam>
    public abstract class AManagerEventsControllerScript<T> : AControllerScript, IManagerEventsController<T> where T : AManagerScript<T>
    {
        /// <summary>
        /// Manager
        /// </summary>
        private T manager;

        /// <summary>
        /// Manager
        /// </summary>
        public T Manager
        {
            get => manager;
            set
            {
                if (!manager && value)
                {
                    manager = value;
                    RegisterManagerEvents();
                }
            }
        }

        /// <summary>
        /// Registers manager events
        /// </summary>
        protected abstract void RegisterManagerEvents();

        /// <summary>
        /// Unregisters manager events
        /// </summary>
        protected abstract void UnregisterManagerEvents();

        /// <summary>
        /// Registers manager events (internal)
        /// </summary>
        private void RegisterManagerEventsInternal()
        {
            if (!manager && AManagerScript<T>.Instance)
            {
                manager = AManagerScript<T>.Instance;
                RegisterManagerEvents();
            }
        }

        /// <summary>
        /// Unregisters manager events (internal)
        /// </summary>
        private void UnregisterManagerEventsInternal()
        {
            if (manager)
            {
                UnregisterManagerEvents();
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
