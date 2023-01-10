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
    /// <typeparam name="TManagerScript">Manager script type</typeparam>
    public abstract class AManagerScript<TManagerScript> : AControllerScript, IManager where TManagerScript : AManagerScript<TManagerScript>
    {
        /// <summary>
        /// Is not destroying on load
        /// </summary>
        [SerializeField]
        private bool isNotDestroyingOnLoad;

        /// <summary>
        /// Manager instance
        /// </summary>
        public static TManagerScript Instance { get; private set; }

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
                Instance = (TManagerScript)this;
                if (isNotDestroyingOnLoad)
                {
                    DontDestroyOnLoad(gameObject);
                }
                foreach
                (
                    AManagerEventsControllerScript<TManagerScript> manager_events_controller in
                        FindObjectsOfType<AManagerEventsControllerScript<TManagerScript>>(false)
                )
                {
                    manager_events_controller.Manager = (TManagerScript)this;
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
                foreach (AManagerEventsControllerScript<TManagerScript> manager_events_controller in FindObjectsOfType<AManagerEventsControllerScript<TManagerScript>>(false))
                {
                    manager_events_controller.Manager = (TManagerScript)this;
                }
            }
        }
    }
}
