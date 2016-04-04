using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour
{

    // Variables
    private GameObject spawner;
    public GameObject enemy;
    public float spawnTime = .5f;
    public Transform[] spawnPoints;
    private PlayerHealth playerHealth;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 2f, spawnTime);
    }

    void Spawn()
    {
        // If the player has no healcurrentHealthth left...
        //if (playerHealth.currentHealth <= 0f)
        //{
        //    // ... exit the function.
        //    return;
        //}

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length-1);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject zombie = objectPool.current.getPooledObject(objectPool.POOL.Zombies);
        if (zombie != null)
        {
            zombie.transform.position = spawnPoints[spawnPointIndex].position;
            zombie.SetActive(true);
        }
    }
}
