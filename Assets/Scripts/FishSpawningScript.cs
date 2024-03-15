using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawningScript : MonoBehaviour
{
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] GameManagerScript gms;
    private GameObject fish;


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
            if (gms.tripleShot) {
                fish = Instantiate(objectToSpawn, mousePosition, new Quaternion(0f,0f,0f,0f));
                fish.GetComponent<FishyMoving>().direction = new Vector2(1f, 1.53747533092f);

                fish = Instantiate(objectToSpawn, mousePosition, new Quaternion(0f,0f,0f,0f));
                fish.GetComponent<FishyMoving>().direction = new Vector2(1f, 0f);

                fish = Instantiate(objectToSpawn, mousePosition, new Quaternion(0f,0f,0f,0f));
                fish.GetComponent<FishyMoving>().direction = new Vector2(1f, -1.53747533092f);
                
                gms.fishShot += 3;
            }
            else {
                Instantiate(objectToSpawn, mousePosition, Quaternion.identity);
                gms.fishShot += 1;
            }
        }
   }
}
