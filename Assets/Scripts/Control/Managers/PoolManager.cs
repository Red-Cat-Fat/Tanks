using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
    [SerializeField]
    private Dictionary<GameObject, Pool> _pools = new Dictionary<GameObject, Pool>();

    public GameObject Spawn(GameObject prefab)
    {
        return Spawn(prefab, Vector3.zero, Quaternion.identity);
    }

    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        Pool pool;

        if (_pools.TryGetValue(prefab, out pool))
        {
            var poolObject = pool.Get();
            poolObject.transform.position = position;
            poolObject.transform.rotation = rotation;
            if (parent != null)
            {
                poolObject.transform.SetParent(parent, true);
            }
            poolObject.gameObject.SetActive(true);
            return poolObject.gameObject;
        }
        return GameObject.Instantiate(prefab, position, rotation);
    }

    public void Despawn(GameObject go)
    {
        var poolObject = go.GetComponent<PoolObject>();
        if (poolObject != null)
        {
            try
            {
                poolObject.Pool.Despawn(poolObject);
            }
            catch
            {
                GameObject.Destroy(go.gameObject);
            }
        }
        else
        {
            GameObject.Destroy(go.gameObject);
        }
    }

    public void Prespawn(GameObject prefab, int count)
    {
        Pool pool;
        if (!_pools.TryGetValue(prefab, out pool))
        {
            pool = new Pool(prefab, transform);
            _pools.Add(prefab, pool);
        }
        for (int i = 0; i < count; ++i)
        {
            pool.Add();
        }
    }
}
