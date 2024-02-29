using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishyMoving : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb; 
    [SerializeField] HingeJoint2D joint;
    [SerializeField] FishyMoving fishScript;
    [SerializeField] SpriteRenderer sr;
    private GameManagerScript gms;

    public bool moving = true;
    public bool attached = false;

    // Start is called before the first frame update
    void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving) {
            if (gms.goingRight) {
                Vector2 movement = new Vector2(1f, 0f);
                GetComponent<Rigidbody2D>().velocity = movement * 5;
            }
            else {
                Vector2 movement = new Vector2(-1f, 0f);
                GetComponent<Rigidbody2D>().velocity = movement * 5;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col) {
        fishScript = col.gameObject.GetComponent<FishyMoving>();

        if (col.gameObject.CompareTag("Fish") && !moving && !(fishScript.attached)) {
            Debug.Log("FishTouch");
            joint = gameObject.AddComponent<HingeJoint2D>();
            joint.connectedBody = col.rigidbody;
            joint.connectedAnchor = col.GetContact(0).point;
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

            fishScript.moving = false;
            fishScript.attached = true;
            //col.gameObject.transform.SetParent(transform.parent);

        }
    }
}
