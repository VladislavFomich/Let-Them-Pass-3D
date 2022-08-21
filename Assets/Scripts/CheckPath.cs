using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class CheckPath : MonoBehaviour
{
    public Action OnPassValid;

    [SerializeField] private Transform _destinationPoint;

    private DrawPath _drawPath;
    private NavMeshAgent _agent;
    private NavMeshPath _path;
    

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _path = new NavMeshPath();
        _drawPath = GetComponent<DrawPath>();
    }


    private void Update()
    {
        _agent.CalculatePath(_destinationPoint.transform.position, _path);

        if (_path.status == NavMeshPathStatus.PathComplete)
        {
            OnPassValid?.Invoke();
        }
          _drawPath.Draw(_path);
    }
   
  

}

