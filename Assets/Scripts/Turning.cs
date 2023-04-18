using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turning : MonoBehaviour
{
    [SerializeField] Transform leftHand;    // attach LeftHandControllerAnchor
    [SerializeField] Transform rightHand;   // attach RightHandControllerAnchor
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
        
        // note: if sticking with this movement plan, change to ~0.06 units
        // if the left hand is higher by 0.09 units, report wanting to turn right
        if (leftPosition.y - rightPosition.y > 0.09)
        {
            turnLeft = false;
            turnRight = true;
            Debug.Log("RIGHT " + turnRight);
        }
        // if the right hand is higher by 0.09 units, report wanting to turn left
        else if (rightPosition.y - leftPosition.y > 0.09)
        {
            turnRight = false;
            turnLeft = true;
            Debug.Log("LEFT " + turnLeft);
        }
        // don't report turning
        else 
        {
            turnLeft = false;
            turnRight = false;
            Debug.Log("NEITHER " + turnLeft + " " + turnRight);
        }
    }
}
