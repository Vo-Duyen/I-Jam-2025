using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPoolConfig", menuName = "Pooling/New Object Pool Config")]
public class ObjectPoolConfig : ScriptableObject
{
    public GameObject objPrefab;
    public int maxPoolSize = 10;
}
