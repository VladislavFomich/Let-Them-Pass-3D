using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : Singleton<PlayerPool>
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform poolTransform;
    [SerializeField] private int amount = 0;
    [SerializeField] private bool populateOnStart = true;
    [SerializeField] private bool growOverAmount = true;

    private int _activePlayer;
    public int ActivePlayer { get => _activePlayer; }
    public int Amount { get => amount; }

    private List<GameObject> _pool = new List<GameObject>();

    void Awake()
    {
        if (populateOnStart && player != null && amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(player);
                instance.transform.parent = poolTransform;
                instance.SetActive(false);
                _pool.Add(instance);
            }
        }
    }

    public GameObject Instantiate(Vector3 position, Quaternion rotation)
    {
        foreach (var item in _pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = position;
                item.transform.rotation = rotation;
                item.GetComponent<MovePlayer>().CustomStart();
                item.SetActive(true);
                _activePlayer++;
                return item;
            }
        }

        if (growOverAmount)
        {
            var instance = Instantiate(player, position, rotation);
            _activePlayer++;
            instance.transform.parent = poolTransform;
            _pool.Add(instance);
            return instance;
        }

        return null;
    }
    public void DestroyBall(int num)
    {
            for (int i = 0; i < num; i++)
            {
              if (_pool[i].activeInHierarchy)
            {
                _pool[i].SetActive(false);
                DecreaseBalls();
            }
        }
    }
    public void DecreaseBalls()
    {
        _activePlayer--;
    }
}
