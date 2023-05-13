using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] Transform leftHand;    // attach LeftHandControllerAnchor
    [SerializeField] Transform rightHand;   // attach RightHandControllerAnchor
<<<<<<< HEAD

    Rigidbody body;
    float angular_velocity;
=======
    bool turnLeft;
    bool turnRight;
>>>>>>> ed99212cb8b3874babab9657a3d70e39c5b4e595

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        angular_velocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 leftPosition = leftHand.position;
        Vector3 rightPosition = rightHand.position;
<<<<<<< HEAD

        bool turnLeft = rightPosition.y - leftPosition.y > 0.09;
        bool turnRight = leftPosition.y - rightPosition.y > 0.09;

        Debug.Log("Turnright: " + turnRight + ", " + (leftPosition.y - rightPosition.y));

        angular_velocity = 0.0f;
        if (turnLeft && transform.rotation.eulerAngles.y > -45.0)
=======
        
        // note: if sticking with this movement plan, change to ~0.06 units
        // if the left hand is higher by 0.09 units, report wanting to turn right
        if (leftPosition.y - rightPosition.y > 0.09)
>>>>>>> ed99212cb8b3874babab9657a3d70e39c5b4e595
        {
            //angular_velocity -= 5.0f;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left*4);
            Debug.Log("Turning left");
        }
<<<<<<< HEAD
        if (turnRight/* && transform.rotation.eulerAngles.y < 45.0*/)
=======
        // if the right hand is higher by 0.09 units, report wanting to turn left
        else if (rightPosition.y - leftPosition.y > 0.09)
>>>>>>> ed99212cb8b3874babab9657a3d70e39c5b4e595
        {
            //angular_velocity += 5.0f;
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right*4);
            Debug.Log("Turning right");

        }
<<<<<<< HEAD

        if (transform.position.z > 200)
=======
        // don't report turning
        else 
>>>>>>> ed99212cb8b3874babab9657a3d70e39c5b4e595
        {
            transform.position = new Vector3(0, 27.473f, -88.491f);
        }
    }

    void FixedUpdate()
    {
        Quaternion delta_rotation = Quaternion.Euler(0.0f, angular_velocity * Time.fixedDeltaTime, 0.0f);
        body.MoveRotation(body.rotation * delta_rotation);
    }
}
