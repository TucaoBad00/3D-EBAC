using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Sigleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static Singleton<T> Instance;
        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);

            }
        }
    }
}
