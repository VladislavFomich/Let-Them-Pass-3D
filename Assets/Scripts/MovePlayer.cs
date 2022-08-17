using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private CheckPath checkPath;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        checkPath.OnPassValid += Move;
    }


    public void Move(Vector3 destination)
    {
        checkPath.OnPassValid -= Move;
        _agent.destination = destination;
    }
}

