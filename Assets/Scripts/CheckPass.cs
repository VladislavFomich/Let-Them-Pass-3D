using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class CheckPass : MonoBehaviour
{
    public Action<Vector3> OnPassValid;

    [SerializeField] private Transform _destinationPoint;
    private NavMeshAgent _agent;
    private NavMeshPath _path;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _path = new NavMeshPath();
    }

    private void Update()
    {
        _agent.CalculatePath(_destinationPoint.transform.position, _path);

        if (_path.status == NavMeshPathStatus.PathComplete)
        {
            if(OnPassValid != null)
            {
              OnPassValid(_destinationPoint.transform.position);
            }
        }
    }
}

