#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityPatterns.Controllers;

/// <summary>
/// Unity Patterns triggers namespace
/// </summary>
namespace UnityPatterns.Triggers
{
    /// <summary>
    /// An abstract class that describes a trigger script
    /// </summary>
    public abstract class ATriggerScript : AControllerScript, ITrigger
    {
        /// <summary>
        /// When should this trigger be destroyed?
        /// </summary>
        [SerializeField]
        private EDestroyingTriggerWhen destroyingTriggerWhen = EDestroyingTriggerWhen.Start;

        /// <summary>
        /// Is destroying entire game object
        /// </summary>
        [SerializeField]
        private bool isDestroyingEntireGameObject;

        /// <summary>
        /// Destruction time
        /// </summary>
        [SerializeField]
        [Min(0.0f)]
        private float destructionTime;

        /// <summary>
        /// When should this trigger be destroyed?
        /// </summary>
        public EDestroyingTriggerWhen DestroyingTriggerWhen
        {
            get => destroyingTriggerWhen;
            set => destroyingTriggerWhen = value;
        }

        /// <summary>
        /// Is destroying entire game object
        /// </summary>
        public bool IsDestroyingEntireGameObject
        {
            get => isDestroyingEntireGameObject;
            set => isDestroyingEntireGameObject = value;
        }

        /// <summary>
        /// Destruction time
        /// </summary>
        public float DestructionTime
        {
            get => destructionTime;
            set => destructionTime = Mathf.Max(value, 0.0f);
        }

        /// <summary>
        /// Is destroyed
        /// </summary>
        public bool IsDetroyed { get; private set; }

        /// <summary>
        /// Destroys this trigger
        /// </summary>
        private void DestroyMe()
        {
            if
            (
#if UNITY_EDITOR
                !EditorApplication.isPlaying &&
#endif
                !IsDetroyed
            )
            {
                IsDetroyed = true;
                Destroy(isDestroyingEntireGameObject ? gameObject : (Object)this, destructionTime);
            }
        }

        /// <summary>
        /// Gets invoked when script gets initialized
        /// </summary>
        protected virtual void Awake()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.Awake)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script gets destroyed
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnDestroy)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script gets enabled
        /// </summary>
        protected virtual void OnEnable()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnEnable)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets destroyed when script gets disabled
        /// </summary>
        protected virtual void OnDisable()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnDisable)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script has been started
        /// </summary>
        protected virtual void Start()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.Start)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script performs a frame update
        /// </summary>
        protected virtual void Update()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.Update)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script perfoms a physics udpate
        /// </summary>
        protected virtual void FixedUpdate()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.FixedUpdate)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script enters a collision
        /// </summary>
        /// <param name="collision">Collision</param>
        protected virtual void OnCollisionEnter(Collision collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnCollisionEnter)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script stays within a collision
        /// </summary>
        /// <param name="collision">Collision</param>
        protected virtual void OnCollisionStay(Collision collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnCollisionStay)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script exists a collision
        /// </summary>
        /// <param name="collision">Collision</param>
        protected virtual void OnCollisionExit(Collision collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnCollisionExit)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script enters a trigger
        /// </summary>
        /// <param name="other">Other trigger</param>
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnTriggerEnter)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script stays within a trigger
        /// </summary>
        /// <param name="other">Other trigger</param>
        protected virtual void OnTriggerStay(Collider other)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnTriggerStay)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script exists a trigger
        /// </summary>
        /// <param name="other">Other trigger</param>
        protected virtual void OnTriggerExit(Collider other)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnTriggerExit)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script enters a 2D collision
        /// </summary>
        /// <param name="collision">Collision</param>
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnCollisionEnter2D)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script stays within a 2D collision
        /// </summary>
        /// <param name="collision">Collision</param>
        protected virtual void OnCollisionStay2D(Collision2D collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnCollisionStay2D)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script exists a 2D collision
        /// </summary>
        /// <param name="collision">Collision</param>
        protected virtual void OnCollisionExit2D(Collision2D collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnCollisionExit2D)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script enters a 2D trigger
        /// </summary>
        /// <param name="other">Other 2D trigger</param>
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnTriggerEnter2D)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script stays within a 2D trigger
        /// </summary>
        /// <param name="other">Other 2D trigger</param>
        protected virtual void OnTriggerStay2D(Collider2D collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnTriggerStay2D)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when script exists a trigger
        /// </summary>
        /// <param name="other">Other trigger</param>
        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnTriggerExit2D)
            {
                DestroyMe();
            }
        }

        /// <summary>
        /// Gets invoked when any particles in a particle system meet the conditions in the triggers module
        /// </summary>
        protected virtual void OnParticleTrigger()
        {
            if (destroyingTriggerWhen == EDestroyingTriggerWhen.OnParticleTrigger)
            {
                DestroyMe();
            }
        }
    }
}
