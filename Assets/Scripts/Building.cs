    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private Rigidbody _rb;
    private bool isDragged;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        isDragged = false;
    }
    private void Start()
    {
        _rb.isKinematic = true; 
    }

    public void ActiveDrag(bool isActive)
    {
        _rb.isKinematic = !isActive;
        isDragged = isActive;
    }

    public void Move(float speed, Vector3 hitPoint)
    {
        if (isDragged)
        {
            Vector3 direction = (hitPoint - transform.position).normalized; 
            print(direction);
            _rb.AddForce(direction * speed);
        }
    }
    private void FixedUpdate()
    {    
        if (!isDragged)
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
