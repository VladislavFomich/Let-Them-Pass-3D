using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovePlayer : MonoBehaviour
{
    private CheckPath _checkPath;
    private Vector3 _destination;
    private NavMeshAgent _agent;
    private bool _canGo;

    private void Awake()
    {
        _checkPath = GameObject.FindGameObjectWithTag("CheckPath").GetComponent<CheckPath>();
        _destination = GameObject.FindGameObjectWithTag("DestinationPoint").GetComponent<Transform>().position;
        _agent = GetComponent<NavMeshAgent>();
        _checkPath.OnPassValid += Move;
    }

    private void Update()
    {
        if (_canGo)
        {
            _agent.destination = _destination;
        }
        else
        _agent.isStopped = true;

    }
    public void Move()
    {
        print(3);
        _canGo = true;
        _checkPath.OnPassValid -= Move;
    }

    public void StopPlayer()
    {
        _canGo=false;
    }
}


