using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] Transform leftHand;    // attach LeftHandControllerAnchor
    [SerializeField] Transform rightHand;   // attach RightHandControllerAnchor

    [SerializeField] GameManager gameManager;

    Rigidbody body;
    float angular_velocity;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        angular_velocity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.gameStarted)
        {

            Vector3 leftPosition = leftHand.position;
            Vector3 rightPosition = rightHand.position;

            bool turnLeft = rightPosition.y - leftPosition.y > 0.09;
            bool turnRight = leftPosition.y - rightPosition.y > 0.09;

            Debug.Log("Turnright: " + turnRight + ", " + (leftPosition.y - rightPosition.y));

            angular_velocity = 0.0f;
            if (turnLeft && transform.rotation.eulerAngles.y > -45.0)
            {
                //angular_velocity -= 5.0f;
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * 10);
                Debug.Log("Turning left");
            }
            if (turnRight/* && transform.rotation.eulerAngles.y < 45.0*/)
            {
                //angular_velocity += 5.0f;
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 10);
                Debug.Log("Turning right");

            }

            if (transform.position.z > 200)
            {
                transform.position = new Vector3(0, 27.473f, -88.491f);
            }
        }
    }

    void FixedUpdate()
    {
        if (gameManager.gameStarted)
        {
            Quaternion delta_rotation = Quaternion.Euler(0.0f, angular_velocity * Time.fixedDeltaTime, 0.0f);
            body.MoveRotation(body.rotation * delta_rotation);
        }
    }
}
