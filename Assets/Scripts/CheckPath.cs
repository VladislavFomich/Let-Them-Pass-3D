using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Threading;

[RequireComponent(typeof(NavMeshAgent))]
public class CheckPath : Singleton<CheckPath>
{
    public Action OnPassValid;

    [SerializeField] private Transform _destinationPoint;

    private DrawPath _drawPath;
    private NavMeshAgent _agent;
    private NavMeshPath _path;
    bool isDraw = true;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _path = new NavMeshPath();
        _drawPath = GetComponent<DrawPath>();
    }
    private void Start()
    {
        StartCoroutine(FirstDraw());
        
    }
    IEnumerator FirstDraw()
    {

        yield return new WaitForSeconds(0.3f);
        _agent.CalculatePath(_destinationPoint.transform.position, _path);
        _drawPath.Draw(_path);
        if (isDraw)
        {
            isDraw = false;
        }
    }


    public void UpdateCheckPath()
    {
        _agent.CalculatePath(_destinationPoint.transform.position, _path);

        if (_path.status == NavMeshPathStatus.PathComplete)
        {
            OnPassValid?.Invoke();
        }
        _drawPath.Draw(_path);
    }

}
