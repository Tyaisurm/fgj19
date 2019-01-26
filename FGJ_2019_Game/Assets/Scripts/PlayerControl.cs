using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    public float gravity;
    public GameObject blast;
    public GameObject smoke;
    public GameObject destination;
    public GameObject camera;

    public float actualSpeed;
    
    private Rigidbody rb;
    private Vector3 lastPosition;
    private GameObject arrow;
    private Vector3 lookVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = Vector3.zero;

        arrow = this.gameObject.transform.GetChild(1).gameObject;
        //arrow.transform.forward = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up")) {
            rb.AddForce(transform.up * speed * Time.deltaTime * 2);
        } else if (Input.GetKey("down")) {
            rb.AddForce(-transform.up * speed * Time.deltaTime * 2);
        }
        if (Input.GetKey("left")) {
            rb.AddTorque(transform.forward * Time.deltaTime * speed);
        } else if (Input.GetKey("right")) {
            rb.AddTorque(-transform.forward * Time.deltaTime * speed);
        }

        Instantiate(smoke, transform.position - transform.up / 3, transform.rotation);

        lookVector = destination.transform.position - arrow.transform.position;
        arrow.transform.LookAt(camera.transform.position, lookVector);
    }

    void FixedUpdate()
    {
        actualSpeed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }  

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Gravity") {
            if (actualSpeed > 0.03 || other.tag == "Sun") {
                Instantiate(blast, transform.position, transform.rotation);
                Destroy(gameObject);
            } else {
                // TODO: go to planet
            }
        }
    }
}
