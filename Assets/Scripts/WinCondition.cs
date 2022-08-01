using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        winCanvas.active = true;
    }
}
