using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    static int STATE_MAIN_MENU = 0;
    static int STATE_STARTED = 1;
    static int STATE_GAME_OVER = 2;

    public bool gameStarted = false;
    private int gameState = STATE_MAIN_MENU;

    public GameObject sled;
    public GameObject startMenuCanvas;
    public GameObject gameOverCanvas;

    private Vector3 sledStartPosition;


    void Start()
    {
        sledStartPosition = sled.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Signal to start game
        if ((gameState == STATE_MAIN_MENU || gameState == STATE_GAME_OVER) && triggerIsDown())
        {
            startGame();
        }
    }


    public void startGame()
    {
        // Turn gravity on for sled
        sled.GetComponent<Rigidbody>().useGravity = true;
        startMenuCanvas.SetActive(false);

        gameStarted = true;
        gameState = STATE_STARTED;
    }

    public void endGame()
    {   
        // Stop all sled motion
        Rigidbody sledRigidBody = sled.GetComponent<Rigidbody>();
        sledRigidBody.useGravity = false;
        sledRigidBody.velocity = Vector3.zero;

        // Move sled back to start
        sled.transform.position = sledStartPosition;

        // Show game over panel
        gameOverCanvas.SetActive(true);

        gameState = STATE_GAME_OVER;
        gameStarted = false;
    }

    private bool triggerIsDown()
    {
        bool down = OVRInput.Get(OVRInput.RawButton.LIndexTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger);
        return down;
    }

}
