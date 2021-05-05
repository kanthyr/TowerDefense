using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float moveSpeed = 15f;

    GameObject[] waypointsQueue;
    int waypointNumber = 0;

    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = moveSpeed;
        waypointsQueue = GameObject.FindGameObjectsWithTag("Waypoint");
        _agent.SetDestination(waypointsQueue[waypointNumber].transform.position);
    }

    void LateUpdate()
    {
        if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            waypointNumber = (waypointNumber + 1);
            if ((waypointNumber < waypointsQueue.Length)) 
            {
                _agent.SetDestination(waypointsQueue[waypointNumber].transform.position);
                return;
            }
            _agent.ResetPath();
        }


    }
}
