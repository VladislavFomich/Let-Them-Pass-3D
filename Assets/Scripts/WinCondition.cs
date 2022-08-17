using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private int winCount;

    public int WinCount { get => winCount; }
    
    public void ActiveWinCanvas()
    {
        winCanvas.SetActive(true);
    }
}
