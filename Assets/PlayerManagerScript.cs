using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{

    [SerializeField] GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 0 represents the left mouse button
        {
            // Get the mouse position in the world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Ensure the z-coordinate is appropriate for your game

            // Instantiate the prefab at the mouse position
            Instantiate(objectToSpawn, mousePosition, Quaternion.identity);
        }
    }
}
