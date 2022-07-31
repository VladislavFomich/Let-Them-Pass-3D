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

    public void ActiveDrag(bool isActive)
    {
        isDragged = isActive;
    }

    public void Move(float speed, Vector3 hitPoint)
    {
        if (isDragged)
        {
            Vector3 direction = (hitPoint - transform.position).normalized;
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
