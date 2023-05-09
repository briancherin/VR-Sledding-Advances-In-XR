using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameStarted = false;

    public GameObject sled;
    public GameObject uiCanvas;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Signal to start game
        if (!gameStarted && triggerIsDown())
        {
            startGame();
        }
    }


    public void startGame()
    {
        // Turn gravity on for sled
        sled.GetComponent<Rigidbody>().useGravity = true;
        uiCanvas.SetActive(false);

        gameStarted = true;
    }

    private bool triggerIsDown()
    {
        bool down = OVRInput.Get(OVRInput.RawButton.LIndexTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger);

        Debug.Log("Trigger down? " + down);

        return down;
    }

}
