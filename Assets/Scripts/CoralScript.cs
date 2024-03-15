using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralScript : MonoBehaviour
{
    private HingeJoint2D joint;
    [SerializeField] FishyMoving fishScript;
    [SerializeField] float yOffset = 0f;
    [SerializeField] Rigidbody2D coralRigidbody;
    [SerializeField] Sprite tendrilSprite;
    [SerializeField] float force = 100;

    public float amplitude = 1f; // Adjust to control the height of the motion
    public float frequency = 1f; // Adjust to control the speed of the motion
    public float moveSpeed = 2f;

    private Vector2 direction;




    private float startTime;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("Jump", 3f);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        /*float verticalPosition = (Mathf.Sin((Time.time - startTime) * frequency) * amplitude) + yOffset;

        // Calculate the velocity based on the desired speed
        float verticalVelocity = Mathf.Cos((Time.time - startTime) * frequency) * amplitude * Mathf.PI * frequency * moveSpeed;

        // Set the position of the coral
        Vector2 newPosition = new Vector2(transform.position.x, verticalPosition);
        coralRigidbody.MovePosition(newPosition);

        // Set the velocity of the coral
        Vector2 newVelocity = new Vector2(0f, verticalVelocity);
        coralRigidbody.velocity = newVelocity;*/
        
    }

    void OnCollisionEnter2D(Collision2D col) {

        fishScript = col.gameObject.GetComponent<FishyMoving>();

        if (col.gameObject.CompareTag("Fish") && !(fishScript.attached)) {

            fishScript.moving = false;
            col.gameObject.transform.SetParent(transform);

            //Sprite
            //col.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            //col.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            col.gameObject.GetComponent<SpriteRenderer>().sprite = tendrilSprite;
            //col.gameObject.GetComponent<SpriteRenderer>().flipX = false;


            //col.transform.localScale = new Vector3(.2f,.2f,.2f);
            col.transform.localScale = new Vector3(1f,1f,1f);

            //col.transform.GetComponent<SpriteRenderer>()

            col.transform.GetComponent<CapsuleCollider2D>().size = new Vector2(4f,1f);
            //col.transform.rotation = new Quaternion(0f,0f,90f,0f);



            col.transform.GetChild(0).gameObject.SetActive(true);

            joint = gameObject.AddComponent<HingeJoint2D>();
            joint.connectedBody = col.rigidbody;
            joint.connectedAnchor = col.GetContact(0).point;

            fishScript.attached = true;
        }
    }

    void Jump() {
        /*
        Acts as the movement system for the jellyfish. They will pick a random direction and jumps there a random amount of force.
        Then it is called again after a random period of time. These jellyfish will always be moving.
        */
        // Picks random direction.
        direction = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f)).normalized;

        // Jumps in that direction with random force.
        coralRigidbody.AddForce(direction * force * Random.Range(.75f, 1.5f), ForceMode2D.Impulse);

        // Calls the Jump function again after a random period of time.
        Invoke("Jump", Random.Range(1.75f,5f));
    }
}