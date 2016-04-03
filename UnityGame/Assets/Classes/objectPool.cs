using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectPool : MonoBehaviour
{

    // Variables
    public static objectPool current;
    public GameObject pooledObject;
    public int pooledAmnt = 20;
    public bool willGrow = true;
    public int numPools;

    // insert more pool types for added functionality
    public enum POOL
    {
        Bullets,
        Zombies,
        NumberOfPools = 2
    }

    List<GameObject> objs;
    List<List<GameObject>> Pools;

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start()
    {
        numPools = (int)POOL.NumberOfPools;
        Pools = new List<List<GameObject>>();

        for (int j = 0; j < numPools; j++)
        {
            objs = new List<GameObject>();

            for (int i = 0; i < pooledAmnt; i++)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);
                obj.SetActive(false);
                objs.Add(obj);
            }

            Pools.Add(objs);
        }
    }

    // used to get 
    protected List<GameObject> getPooledList(int i)
    {
        return Pools[i];
    }

    public GameObject getPooledObject(int poolIndex)
    {
        List<GameObject> objs = getPooledList(poolIndex);

        for (int i = 0; i < objs.Count; i++)
        {
            if (!objs[i].activeInHierarchy)
            {
                return objs[i];
            }
        }

        if (willGrow)
        {
            GameObject newObj = Instantiate(pooledObject);
            objs.Add(newObj);
            return newObj;
        }

        return null;
    }

}
