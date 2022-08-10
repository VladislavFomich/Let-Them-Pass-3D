using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

  [RequireComponent(typeof(LineRenderer))]
public class DrawPath : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    public void Draw(NavMeshPath _path)
    {
        _lineRenderer.positionCount = _path.corners.Length;
        for (int i = 0; i < _path.corners.Length; i++)
        {
            _lineRenderer.SetPosition(i, _path.corners[i]);
        }
    }

}
