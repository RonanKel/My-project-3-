using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletionScript : MonoBehaviour
{

    [SerializeField] GameManagerScript gms;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        gms.fishCollected += 1;
        Destroy(col.gameObject);
    }
}
