using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private CheckPass checkPass;

    private Camera _cam;
    private Building _building;

    private LayerMask _layerHouse;
    private LayerMask _layerPlane;


    private void Awake()
    {
        _cam = Camera.main;
        _layerHouse = LayerMask.GetMask("House");
        _layerPlane = LayerMask.GetMask("Plane");
        checkPass.OnPassValid += StopMove;
    }
    private void Update()
    {
        if (InputController.Instance.GetPointerDown)
        {
            Ray rayHouse = _cam.ScreenPointToRay(InputController.Instance.PointerPosition);
            RaycastHit hitHouse;

            if (Physics.Raycast(rayHouse, out hitHouse, Mathf.Infinity, _layerHouse))
            {
                _building = hitHouse.transform.GetComponent<Building>();
                _building.ActiveDrag(true);
            }
        }
        else if (InputController.Instance.GetPointerUp)
        {
            if(_building != null)
            {
              _building.ActiveDrag(false);
            }
        }
    }

    private void FixedUpdate()
    {     
        if (InputController.Instance.GetPointerHeld)
        {
            Ray rayPlane = _cam.ScreenPointToRay(InputController.Instance.PointerPosition);
            RaycastHit hitPlane;
            if (Physics.Raycast(rayPlane, out hitPlane, Mathf.Infinity, _layerPlane))
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
        this.enabled = false;
    }
}