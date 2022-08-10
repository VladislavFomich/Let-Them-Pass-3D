using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    [SerializeField] private Vector3 gridSize = default;
    public float speed;
    Rigidbody rb;
    Vector3 position;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SnapToGrid();
    }
   private void SnapToGrid()
    {
            position = new Vector3(
            Mathf.Round(this.transform.position.x / this.gridSize.x) * this.gridSize.x,
            Mathf.Round(this.transform.position.y / this.gridSize.y) * this.gridSize.y,
            Mathf.Round(this.transform.position.z / this.gridSize.z) * this.gridSize.z);
     //  this.transform.position = position;    
        transform.position = Vector3.MoveTowards(transform.position, position, speed);
    }
    private void FixedUpdate()
    {
      // rb.MovePosition(speed * Time.deltaTime * position);
    }
}
