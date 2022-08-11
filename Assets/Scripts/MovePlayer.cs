using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private CheckPath checkPath;
    [SerializeField] private Transform startPoint;
    private bool _isStart = true;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        checkPath.OnPassValid += Move;
    }

    private void Update()
    {  
       if (_isStart)
        {
          _agent.destination = startPoint.position;
        }
    }

    public void Move(Vector3 destination)
    {
        _isStart = false;
        checkPath.OnPassValid -= Move;
        _agent.destination = destination;
    }
}

