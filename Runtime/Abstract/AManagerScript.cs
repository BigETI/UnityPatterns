using UnityEngine;
using UnityPatterns.Controllers;

/// <summary>
/// Unity Patterns managers namespace
/// </summary>
namespace UnityPatterns.Managers
{
    /// <summary>
    /// An abstract class that describes a manager script
    /// </summary>
    /// <typeparam name="T">Manager script type</typeparam>
    public abstract class AManagerScript<T> : AControllerScript, IManager where T : AManagerScript<T>
    {
        /// <summary>
        /// Is not destroying on load
        /// </summary>
        [SerializeField]
        private bool isNotDestroyingOnLoad;

        /// <summary>
        /// Manager instance
        /// </summary>
        public static T Instance { get; private set; }

        /// <summary>
        /// Is not destroying on load
        /// </summary>
        public bool IsNotDestroyingOnLoad
        {
            get => isNotDestroyingOnLoad;
            set => isNotDestroyingOnLoad = value;
        }

        /// <summary>
        /// Gets invoked when script gets enabled
        /// </summary>
        protected virtual void OnEnable()
        {
            if (!Instance)
            {
                Instance = (T)this;
                if (isNotDestroyingOnLoad)
                {
                    DontDestroyOnLoad(gameObject);
                }
                foreach (AManagerEventsControllerScript<T> manager_events_controller in FindObjectsOfType<AManagerEventsControllerScript<T>>(false))
                {
                    manager_events_controller.Manager = (T)this;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Gets invoked when script gets disabled
        /// </summary>
        protected virtual void OnDisable()
        {
            if (Instance == this)
            {
                Instance = null;
                foreach (AManagerEventsControllerScript<T> manager_events_controller in FindObjectsOfType<AManagerEventsControllerScript<T>>(false))
                {
                    manager_events_controller.Manager = (T)this;
                }
            }
        }
    }
}
