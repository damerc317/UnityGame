using UnityEngine;
using System.Collections;

public class HealthMechanic : MonoBehaviour
{

    public float max_health, current_health;

    // Use this for initialization
    void Start()
    {
        current_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void AddDamage(float bullet_damage)
    {
        current_health -= bullet_damage;
        Debug.Log("damaged " + current_health);
    }
}