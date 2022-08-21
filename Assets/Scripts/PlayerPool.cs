using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPool : Singleton<PlayerPool>
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform poolTransform;
    [SerializeField] private int amount = 0;
    [SerializeField] private bool populateOnStart = true;
    [SerializeField] private bool growOverAmount = true;
    private int _activeBall = 1;
    public int ActiveBall { get => _activeBall; }

    private List<GameObject> _pool = new List<GameObject>();

    void Awake()
    {
        if (populateOnStart && ball != null && amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(ball);
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
                item.SetActive(true);
                _activeBall++;
                return item;
            }
        }

        if (growOverAmount)
        {
            var instance = Instantiate(ball, position, rotation);
            _activeBall++;
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
        _activeBall--;
    }
}
