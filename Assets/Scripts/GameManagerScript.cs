using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    // The amount of fish a player will start with each round (in this case at the start of the game)
    public int fishTotal = 50;
    // A counter to keep track of how many fish have been shot
    public int fishShot = 0;
    // A counter to keep track of all the fish that make it past the jelly fish
    public int fishCollected = 0;
    // A game state, whether the fish go towards the left or the right
    public bool goingRight = true;

    // The areas that fish can spawn in when clicked
    [SerializeField] GameObject lspawner;
    [SerializeField] GameObject rspawner;


    [SerializeField] GameObject canvas;
    [SerializeField] Button lButton;
        


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If fishTotal is ever equal to 0, that means the player lost all their fish and the game is over
        if (fishTotal <= 0) {
            Debug.Log("You Lose!");
        }
        // If you have shot all the fish you have, the direction of the game will change in 5 seconds
        if (fishShot == fishTotal) {   
            Invoke("PauseGame", 5f);        
            Invoke("Swap", 5f);
            fishShot += 1;
        }
        
    }

    private void Swap() {
        /*
        A function to swap the game state, from the fish going left to the figh going right and vise verca.
            Inputs: None
            Outputs: None
        */

        // Activates and deactivates the proper fish spawn zones
        if (lspawner.activeSelf) {
            lspawner.SetActive(false);
            rspawner.SetActive(true);
        }
        else {
            lspawner.SetActive(true);
            rspawner.SetActive(false);
        }

        // Resets the game data, now you will start with however many fish you collected
        fishTotal = fishCollected;
        fishCollected = 0;
        fishShot = 0;
        // This variable is used by the "FishyMoving" script which lets it determines which direction the fish will move
        goingRight = !goingRight;
    }

    private void PauseGame() {
        Time.timeScale = 0f;
        canvas.SetActive(true);
    }

    public void ContinueGame() {
        Time.timeScale = 1f;
        canvas.SetActive(false);
    }

    /*private void ButtonChange(string text, GameObject button) {
        
    }*/

    public void AddFish(int x) {
        Debug.Log(x);
        fishTotal += x;
        ContinueGame();
    }

    public void InterpretButton(int x) {

    }
}
