using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public int score = 0;
    public GameObject scoreText;
    public GameObject gameRunningCountText; // Score indicator while game is running
    public GameObject finishText; // Text that shows up when game ends

    private Vector3 sledStartPosition;


    void Start()
    {
        sledStartPosition = sled.transform.position;

        gameRunningCountText.SetActive(false);
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
        gameRunningCountText.SetActive(true);

        score = 0;

        gameStarted = true;
        gameState = STATE_STARTED;
    }

    public void endGame(bool wonGame)
    {   
        // Stop all sled motion
        Rigidbody sledRigidBody = sled.GetComponent<Rigidbody>();
        sledRigidBody.useGravity = false;
        sledRigidBody.velocity = Vector3.zero;

        // Move sled back to start
        sled.transform.position = sledStartPosition;

        // Set score
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();

        // Hide in game score text
        gameRunningCountText.SetActive(false);
        gameRunningCountText.GetComponent<TextMeshProUGUI>().text = "Score: 0"; // Reset score text

        // Set finish text
        if (wonGame)
        {
            finishText.GetComponent<TextMeshProUGUI>().text = "Finished!";
        } else
        {
            finishText.GetComponent<TextMeshProUGUI>().text = "You lost!";
        }

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
