using System;
using JetBrains.Annotations;
using UnityEngine;

namespace ImportedTools
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static object m_Lock = new object();
        private static T m_Instance;

        private void Awake()
        {
            if (FindObjectsOfType<T>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            HandleAwake();
        }

        protected virtual void HandleAwake(){}

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        [NotNull]
        public static T Instance
        {
            get
            {
             
                lock (m_Lock)
                {
                    if (m_Instance == null)
                    {
                        // Search for existing instance.
                        m_Instance = (T)FindObjectOfType(typeof(T));
 
                        // Create new instance if one doesn't already exist.
                        if (m_Instance == null)
                        {
                            throw new Exception(typeof(T).FullName + " singleton does not exist");
                        }
                    }
 
                    return m_Instance;
                }
            }
        }
    }
}