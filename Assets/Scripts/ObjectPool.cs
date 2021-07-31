using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected int Capacity;
    [SerializeField] private Transform _container;

    protected List<GameObject> Pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {        
        for (int i = 0; i < Capacity; i++)
        {
            GameObject spawnedGameObject = Instantiate(prefab, _container);
            Pool.Add(spawnedGameObject);
        }
    }
}
