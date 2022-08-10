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


    private LayerMask _layerHouse;
    private LayerMask _layerPlane;

    private int _moveBuildingNum = 0;
    

    private void Awake()
    {
        _cam = Camera.main;
        _layerHouse = LayerMask.GetMask("House");
        _layerPlane = LayerMask.GetMask("Plane");
        checkPath.OnPassValid += StopMove;
    }
    private void Update()
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
               _moveBuildingNum++;
               lvlCanvasView.UpMovesNum(_moveBuildingNum);
              _building.ActiveDrag(false);
             _building.SnapToGrid(true);
              _building = null; 
            }
        }
    }

    private void FixedUpdate()
    {     
        if (InputController.Instance.GetPointerHeld)
        {
            Ray rayPlane = _cam.ScreenPointToRay(InputController.Instance.PointerPosition);
            RaycastHit hitPlane;
            if (Physics.SphereCast(rayPlane,rayRadius, out hitPlane, Mathf.Infinity, _layerPlane))
            {   
                if(_building != null)
                {
                  _building.Move(speed, hitPlane.point);
                }
            }
        }
    }
    public void StopMove(Vector3 point)
    {
        lvlCanvasView.UpMovesNum(_moveBuildingNum+1);
        checkPath.OnPassValid -= StopMove;
        this.enabled = false;
    }
}