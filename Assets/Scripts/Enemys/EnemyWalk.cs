using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyWalk : MonoBehaviour
    {
        [Header("Waypoints")]
        public GameObject[] waypoints;
        public float minDistancce;
        public float speed;

        private int _index;

        private void Update()
        {
            if(Vector3.Distance(transform.position, waypoints[_index].transform.position)<minDistancce)
            {
                _index++;
                if (_index >= waypoints.Length)
                {
                    _index = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[_index].transform.position, Time.deltaTime * speed);
            transform.LookAt(waypoints[_index].transform.position);
        }

        
    }
}