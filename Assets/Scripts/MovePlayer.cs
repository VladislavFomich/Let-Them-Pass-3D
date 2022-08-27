using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovePlayer : MonoBehaviour
{
    private GameObject _destination;
    private Vector3 _destinationPosition;
    private NavMeshAgent _agent;
    private bool _canGo;

    private void Awake()
    {
        _destination = GameObject.FindGameObjectWithTag("DestinationPoint");
        _destinationPosition = _destination.GetComponent<Transform>().position;
        _agent = GetComponent<NavMeshAgent>();
        CheckPath.Instance.OnPassValid += Move;
    }

    private void Update()
    {
        if (_canGo)
        {
            _agent.isStopped = false;
            _agent.destination = _destinationPosition;
        }
        else
        {
            _agent.isStopped = true;
            _destinationPosition = _destination.transform.position;
        }


    }
    public void Move()
    {
        _canGo = true;
    }

    public void StopPlayer()
    {
        _canGo=false;
    }
    public void CustomStart()
    {
        _destinationPosition = _destination.GetComponent<Transform>().position;
    }
}


