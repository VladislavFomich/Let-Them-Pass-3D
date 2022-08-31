using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultuplyPlayers : MonoBehaviour
{ 
     enum Sign { Plus, Minus, Divide, Multiply};
    [SerializeField] private Sign sign;
    [SerializeField] private int num;

    private bool _isMultiply;
    private int _passPLayer;


    private void OnTriggerEnter(Collider other)
    {
        _passPLayer++;

        if(_passPLayer == PlayerPool.Instance.ActivePlayer / 2)
        {
            WinCondition.Instance.ActiveWinCanvas();
            MoveNextStage.Instance.Move();
        }
        
        if (!_isMultiply)
        {
            _isMultiply = true;
        switch (sign)
        {
           case Sign.Plus:
                for (int i = 0; i < num; i++)
                {
                   PlayerPool.Instance.Instantiate(transform.position, Quaternion.identity);
                }
                break;

           case Sign.Minus:
                PlayerPool.Instance.DestroyBall(num);
                break;
            
           case Sign.Multiply:
               int multNum = (num - 1) * PlayerPool.Instance.ActivePlayer;
               for (int i = 0;i < multNum; i++)
                {
                    PlayerPool.Instance.Instantiate(transform.position,Quaternion.identity);
                }
                break;
           case Sign.Divide:
                int num1 = PlayerPool.Instance.ActivePlayer / num;;
                int divideNum = PlayerPool.Instance.ActivePlayer - num1;
                PlayerPool.Instance.DestroyBall(divideNum);
                break;
        }
        }
            
    }
}
