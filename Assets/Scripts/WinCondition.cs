using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : Singleton<WinCondition>
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private int winCount;
    private int _blockPass;

    
    public void ActiveWinCanvas()
    {
        _blockPass++;
        if(_blockPass == winCount)
        {
        winCanvas.SetActive(true);
        }
    }
}
