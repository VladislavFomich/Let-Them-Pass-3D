
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private CheckPath checkPath;
    [SerializeField] private LvlCanvasView lvlCanvasView;
    [SerializeField] private float rayRadius;

    private Camera _cam;
    private Building _building;
    private bool _isPlay = true;


    private LayerMask _layerHouse;
    private LayerMask _layerPlane;



    private void Awake()
    {
        _cam = Camera.main;
        _layerHouse = LayerMask.GetMask("House");
        _layerPlane = LayerMask.GetMask("Plane");
        checkPath.OnPassValid += StopMove;
    }
    private void Update()
    {
        if (_isPlay)
        {
            if (InputController.Instance.GetPointerDown)
            {
                Ray rayHouse = _cam.ScreenPointToRay(InputController.Instance.PointerPosition);
                RaycastHit hitHouse;

                if (Physics.SphereCast(rayHouse, rayRadius, out hitHouse, Mathf.Infinity, _layerHouse))
                {
                    _building = hitHouse.transform.GetComponent<Building>();
                    _building.ActiveDrag(true);
                }
            }
            else if (InputController.Instance.GetPointerUp)
            {
                if (_building != null)
                {
                    _building.ActiveDrag(false);
                    _building.SnapToGrid(true);
                    _building = null;
                }
            }

        }
        else
            _building.SnapToGrid(true);
    }



    private void FixedUpdate()
    {

        if (_isPlay)
        {
            if (InputController.Instance.GetPointerHeld)
            {
                Ray rayPlane = _cam.ScreenPointToRay(InputController.Instance.PointerPosition);
                RaycastHit hitPlane;
                if (Physics.SphereCast(rayPlane, rayRadius, out hitPlane, Mathf.Infinity, _layerPlane))
                {
                    if (_building != null)
                    {
                        _building.Move(speed, hitPlane.point);
                    }
                }
            }

        }
        else
            _building.SnapToGrid(true);
    }
    public void StopMove()
    {
        _isPlay = false;
        checkPath.OnPassValid -= StopMove;
    }
}