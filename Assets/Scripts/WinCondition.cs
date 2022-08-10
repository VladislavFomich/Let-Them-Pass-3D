using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject[] playersList;

    public int PlayerNum { get => playersList.Length; }
    
    public void ActiveWinCanvas()
    {
        winCanvas.SetActive(true);
    }
}
