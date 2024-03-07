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

    public float amplitude = 1f; // Adjust to control the height of the motion
    public float frequency = 1f; // Adjust to control the speed of the motion
    public float moveSpeed = 2f;


    private float timeCounter = 0f;

    private float startTime;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        float verticalPosition = Mathf.Sin((Time.time - startTime) * frequency) * amplitude;

        // Calculate the velocity based on the desired speed
        float verticalVelocity = Mathf.Cos((Time.time - startTime) * frequency) * amplitude * Mathf.PI * frequency * moveSpeed;

        // Set the position of the coral
        Vector2 newPosition = new Vector2(transform.position.x, verticalPosition);
        coralRigidbody.MovePosition(newPosition);

        // Set the velocity of the coral
        Vector2 newVelocity = new Vector2(0f, verticalVelocity);
        coralRigidbody.velocity = newVelocity;
        
    }

    void OnCollisionEnter2D(Collision2D col) {

        fishScript = col.gameObject.GetComponent<FishyMoving>();

        if (col.gameObject.CompareTag("Fish") && !(fishScript.attached)) {

            fishScript.moving = false;
            //col.gameObject.transform.SetParent(transform.parent);

            col.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            col.gameObject.GetComponent<SpriteRenderer>().sprite = tendrilSprite;
            col.gameObject.GetComponent<SpriteRenderer>().flipX = false;

            joint = gameObject.AddComponent<HingeJoint2D>();
            joint.connectedBody = col.rigidbody;
            joint.connectedAnchor = col.GetContact(0).point;
        }
    }
}