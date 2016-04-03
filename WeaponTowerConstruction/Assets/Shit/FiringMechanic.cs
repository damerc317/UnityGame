using UnityEngine;
using System.Collections;

public class FiringMechanic : MonoBehaviour
{

    public Object bullet;
    public Transform gunTip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, gunTip.position, gunTip.rotation);
        }
    }
}