using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] blockPrefab;
    [SerializeField] private int amount;
    private const int distance = 75;

    private void Awake()
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < amount; i++)
        {
            pos = new Vector3(blockPrefab[i].transform.position.x, blockPrefab[i].transform.position.y, i * distance);
            Instantiate(blockPrefab[i],pos, Quaternion.identity);
        }
    }

}
