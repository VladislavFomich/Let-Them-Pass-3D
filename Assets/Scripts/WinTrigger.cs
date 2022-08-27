using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    int num;
    private void OnTriggerEnter(Collider other)
    {
        num++;
        if(num == PlayerPool.Instance.ActivePlayer)
        {
            this.gameObject.SetActive(false);
        }
      MovePlayer movePlayer = other.GetComponent<MovePlayer>();
        if(movePlayer != null)
        {
            movePlayer.StopPlayer();
        }
    }
}
