using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Sprays snow particles around Gameobject when it is in contact with the ground object
 * 
 */
public class SnowSprayGenerator : MonoBehaviour
{

    public GameObject ground;
    public ParticleSystem snowParticleSystem;
    private int sprayMultiplier = 1000;

    private float currentSpeed;
    private bool touchingGround = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        Debug.Log("Speed:" + currentSpeed);


        // If currentSpeed is 0, spray no snow
        // Spray more snow the higher the speed is

        // Only spray snow if the object is touching the ground

        if (touchingGround)
        {
            spraySnow(currentSpeed);
        } else
        {
            spraySnow(0);
        }


    }

    private void spraySnow(float speed)
    {
        var emission = snowParticleSystem.emission;
        emission.rateOverTime = speed * sprayMultiplier;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == ground)
        {
            touchingGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == ground)
        {
            touchingGround = false;
        }
    }
}
