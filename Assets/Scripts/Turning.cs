using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] Transform leftHand;
    [SerializeField] Transform rightHand;
    bool turnLeft;
    bool turnRight;

    // Start is called before the first frame update
    void Start()
    {
        turnLeft = false;
        turnRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 leftPosition = leftHand.position;
        Vector3 rightPosition = rightHand.position;

        // if the left hand is higher by 0.09 units, turn right
        if (leftPosition.y - rightPosition.y > 0.09)
        {
            turnLeft = false;
            turnRight = true;
            Debug.Log("RIGHT " + turnRight);
        }
        else if (rightPosition.y - leftPosition.y > 0.09)
        {
            turnRight = false;
            turnLeft = true;
            Debug.Log("LEFT " + turnLeft);
        }
        else 
        {
            turnLeft = false;
            turnRight = false;
            Debug.Log("NEITHER " + turnLeft + " " + turnRight);
        }
    }
}
