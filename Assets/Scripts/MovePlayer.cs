using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private CheckPass checkPass;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        checkPass.OnPassValid += Move;
    }

    public void Move(Vector3 destination)
    {
        _agent.destination = destination;
    }
}

