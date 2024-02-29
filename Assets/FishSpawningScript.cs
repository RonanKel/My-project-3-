using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawningScript : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] GameManagerScript gms;


    // Start is called before the first frame update
    void Start()
    {      
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
   {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 2; // Ensure the z-coordinate is appropriate for your game

        // Instantiate the prefab at the mouse position
        if (gms.fishShot < gms.fishTotal) {
            Instantiate(objectToSpawn, mousePosition, Quaternion.identity);
            gms.fishShot += 1;
        }
   }
}
