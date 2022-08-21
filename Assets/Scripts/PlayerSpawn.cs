using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(Random.Range(transform.position.x + 5, transform.position.x - 5),transform.position.y, Random.Range(transform.position.z + 3, transform.position.z - 3));
            PlayerPool.Instance.Instantiate(pos, Quaternion.identity);
        }
    }
}
