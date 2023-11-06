using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;
        public virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = GameObject.FindAnyObjectByType<T>();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}