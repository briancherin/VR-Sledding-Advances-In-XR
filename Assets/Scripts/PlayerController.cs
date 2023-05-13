using UnityEngine;

// Include the namespace required to use Unity UI and Input System
/*using UnityEngine.InputSystem;*/
using TMPro;

public class PlayerController : MonoBehaviour
{

    public GameObject countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private static int count = 0;

    // At the start of the game..
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("sled"))
        {
            gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            Debug.Log("Count:" + count);

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.GetComponent<TextMeshProUGUI>().text = "Score: " + count.ToString();

        if (count >= 1)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);

        }
    }
}
