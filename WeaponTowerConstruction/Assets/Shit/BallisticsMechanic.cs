using UnityEngine;
using System.Collections;

public class BallisticsMechanic : MonoBehaviour
{

    public float bullet_firing_velocity, gravity, bullet_damage; //variables
    public Vector3 bullet_velocity = new Vector3(0, 0, 0); //the vector that contains bullet's current speed

    public Vector3 last_position = new Vector3(0, 0, 0), current_position = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        gravity = 9.8f;
        bullet_velocity = transform.forward * bullet_firing_velocity; //bullet velocity = forward vector * bullet firing velocity

        /* linecasting */
        current_position = transform.position;
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = bullet_velocity; //make the bullet's velocity equal to current velocity value
        bullet_velocity.y -= gravity; //decrease the y axis of bullet velocity by amount of gravity
        DestroyObject(gameObject, 3); //destroy bullet after 3 sec's

        /* linecasting */
        RaycastHit hit;
        last_position = current_position;
        current_position = transform.position;
        if (Physics.Linecast(last_position, current_position, out hit))
        {
            hit.transform.SendMessage("AddDamage", bullet_damage, SendMessageOptions.DontRequireReceiver); //Send Damage message to hit object
        }
        Debug.DrawLine(last_position, current_position, Color.red);
    }

    void OnCollisionEnter(Collision target)
    { //If there is a contact...
        Destroy(gameObject); //Destroy bullet
    }
}