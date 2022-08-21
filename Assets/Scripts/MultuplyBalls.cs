using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultuplyBalls : MonoBehaviour
{ 
     enum Sign { Plus, Minus, Divide, Multiply};
    [SerializeField] private Sign sign;
    [SerializeField] private int num;
    private bool _isMultiply;


    private void OnTriggerEnter(Collider other)
    {
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
              int multNum = (num - 1) * PlayerPool.Instance.ActiveBall;
               for (int i = 0;i < multNum; i++)
                {
                    PlayerPool.Instance.Instantiate(transform.position,Quaternion.identity);
                }
                break;
           case Sign.Divide:
                int num1 = PlayerPool.Instance.ActiveBall / num;;
                int divideNum = PlayerPool.Instance.ActiveBall - num1;
                PlayerPool.Instance.DestroyBall(divideNum);
                break;
        }
        }
            
    }
}