using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerToAvatar : MonoBehaviour
{
    [SerializeField] GameObject right_hand;
    [SerializeField] GameObject left_hand;
    [SerializeField] GameObject leftTarget;
    [SerializeField] GameObject rightTarget;
    public int xr = 270;
    public int yr = 0;
    public int zr = 90;
    public int xl = 90;
    public int yl = 180;
    public int zl = 90;
    // public float transform_speed = 0.1f;
    // public float rotation_speed = 0.1f;
    // public float transform_offset = 0.1f;
    // public float rotation_offset = 0.1f;

    Transform objToPickUp;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    
    void Update()
    {

        // Need to set new right and left position
        // Need to use speed and offset variables
        
        rightTarget.transform.position = right_hand.transform.position;
        rightTarget.transform.rotation = right_hand.transform.rotation;
        rightTarget.transform.rotation *= Quaternion.Euler(xr, yr, zr);
        // Debug.Log("controller pos" + right_hand.transform.position + "target position" + rightTarget.transform.position);
        
        leftTarget.transform.position = left_hand.transform.position;
        leftTarget.transform.rotation = left_hand.transform.rotation;
        leftTarget.transform.rotation *= Quaternion.Euler(xl, yl, zl);
        // Debug.Log("controller pos" + left_hand.transform.position + "target position" + leftTarget.transform.position);
        

    }
    

}
