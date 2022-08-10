using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private WinCondition winCondition;
    private int playerNum;

    private void OnTriggerEnter(Collider other)
    {
        playerNum++;
        if(playerNum == winCondition.PlayerNum)
        {
           winCondition.ActiveWinCanvas();
        }
    }
}
