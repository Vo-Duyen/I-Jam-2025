using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ManagerObjectPool : MonoBehaviour
{
    public static ManagerObjectPool Instance;
    private Dictionary<GameObject, MyObjectPool> dict = new Dictionary<GameObject, MyObjectPool>();

    [SerializeField] private List<ObjectPoolConfig> poolConfigs;

    private void Awake()
    {
        Instance = this;
        InitializePools();
    }

    private void InitializePools()
    {
        poolConfigs = new List<ObjectPoolConfig>(Resources.LoadAll<ObjectPoolConfig>("Pooling"));
        foreach (var config in poolConfigs)
        {
            if (config.objPrefab != null)
            {
                dict[config.objPrefab] = new MyObjectPool(config.objPrefab, config.maxPoolSize);
            }
        }
    }

    public GameObject GetFromPool(GameObject obj, Transform parent = null)
    {
        if (dict.ContainsKey(obj) == false)
        {
            dict.Add(obj, new MyObjectPool(obj, 10));
        }
        return dict[obj].Get(parent);
    }
    public void ClearPool()
    {
        foreach (var pool in dict.Values)
        {
            pool.ClearPool();
        }
        dict.Clear();
    }
}
// Class My Object Pool
public class MyObjectPool
{
    public Stack<GameObject> stack = new Stack<GameObject>();
    private GameObject baseObj;
    private int maxPoolSize; 
    private GameObject tmp;
    private MyReturnToPool myReturnToPool;

    public MyObjectPool(GameObject baseObj, int maxPoolSize)
    {
        this.baseObj = baseObj;
        this.maxPoolSize = maxPoolSize;
    }

    public GameObject Get(Transform parent = null)
    {
        if (stack.Count > 0)
        {
            tmp = stack.Pop();
            if (tmp != null)
            {
                tmp.SetActive(true);
                return tmp;
            }
        }
        tmp = GameObject.Instantiate(baseObj, parent);
        myReturnToPool = tmp.AddComponent<MyReturnToPool>();
        myReturnToPool.pool = this;
        return tmp;
    }

    public void AddToPool(GameObject obj)
    {
        if (stack.Count < maxPoolSize)
        {
            obj.SetActive(false);
            stack.Push(obj);
        }
        else
        {
            GameObject.Destroy(obj);
        }
        //Debug.Log(stack.Count);
    }

    public void ClearPool()
    {
        while (stack.Count > 0)
        {
            GameObject obj = stack.Pop();
            if (obj != null)
            {
                GameObject.Destroy(obj);
            }
        }
    }
}
// Class My Return To Pool
public class MyReturnToPool : MonoBehaviour
{
    public MyObjectPool pool;

    private void OnDisable()
    {
        transform.position = Vector3.zero;
        pool.AddToPool(gameObject);
    }
}
