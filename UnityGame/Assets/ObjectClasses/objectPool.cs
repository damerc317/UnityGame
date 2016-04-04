using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class objectPool : MonoBehaviour
{

    // Variables
    public static objectPool current;
    public List<GameObject> pooledObjects;
    public int pooledAmnt = 20;
    public bool willGrow = true;
    public int numPools;

    // insert more pool types for added functionality
    public enum POOL
    {
        Zombies,
        NumberOfPools = 1
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

        // loops through pool types
        for (int j = 0; j < numPools; j++)
        {
            objs = new List<GameObject>();

            // creates a number of objects in each pool type
            for (int i = 0; i < pooledAmnt; i++)
            {
                GameObject obj = Instantiate(pooledObjects[j]);
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

    // gets a single pool from the list of pools and searches it
    public GameObject getPooledObject(POOL poolIndex)
    {
        List<GameObject> objs = getPooledList((int)poolIndex);

        for (int i = 0; i < objs.Count; i++)
        {
            if (!objs[i].activeInHierarchy)
            {
                return objs[i];
            }
        }

        if (willGrow)
        {
            GameObject newObj = Instantiate(pooledObjects[(int)poolIndex]);
            objs.Add(newObj);
            return newObj;
        }

        return null;
    }

}
