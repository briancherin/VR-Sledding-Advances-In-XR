using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject finishLine;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == finishLine)
        {
            gameManager.endGame(true);
        }

        else if (other.gameObject.tag == "tree")
        {
            gameManager.endGame(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
