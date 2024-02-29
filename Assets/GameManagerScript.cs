using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int fishTotal = 50;
    public int fishShot = 0;
    public int fishCollected = 0;
    public bool goingRight = true;

    [SerializeField] GameObject lspawner;
    [SerializeField] GameObject rspawner;
        


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (fishTotal == 0) {
            Debug.Log("You Lose!");
        }
        if (fishShot == fishTotal) {            
            Invoke("Swap", 5f);
            fishShot += 1;
        }
        
    }

    private void Swap() {
        if (lspawner.activeSelf) {
            lspawner.SetActive(false);
            rspawner.SetActive(true);
        }
        else {
            lspawner.SetActive(true);
            rspawner.SetActive(false);
        }
        fishTotal = fishCollected;
        fishCollected = 0;
        fishShot = 0;
        goingRight = !goingRight;
    }
}
