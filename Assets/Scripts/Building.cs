    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 gridSize = default;
    [SerializeField] private float houseLenght;

    private Rigidbody _rb;
    private bool _isDragged;
    private bool _isSnaped = false;
    private Vector3 _snapPos;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _isDragged = false;
        SnapToGrid(true);
    }
    private void Start()
    {
        _rb.isKinematic = true;
    }
    private void Update()
    {
        if (transform.position == _snapPos)
        {
            _isSnaped = false;
            return;
        }
        if (_isSnaped)
        {
            _snapPos = new Vector3(
            Mathf.Round(this.transform.position.x / this.gridSize.x) * this.gridSize.x,
            Mathf.Round(this.transform.position.y / this.gridSize.y) * this.gridSize.y,
            Mathf.Round(this.transform.position.z / this.gridSize.z) * this.gridSize.z);
            transform.position = Vector3.MoveTowards(transform.position, _snapPos, speed);
        }
    }

    public void ActiveDrag(bool isActive)
    {
        _rb.isKinematic = !isActive;
        _isDragged = isActive;
    }

    public void Move(float speed, Vector3 hitPoint)
    {
        if (_isDragged)
        {
            Vector3 direction = ((hitPoint - new Vector3(houseLenght / 2, 0,houseLenght/2)) - transform.position).normalized; 
            _rb.AddForce(direction * speed);
        }
    }
    private void FixedUpdate()
    {    
        if (!_isDragged)
        {
            _rb.velocity = Vector3.zero;
        }
    }
    public void SnapToGrid(bool snaped)
    {
        _isSnaped = snaped;
    }
}
