using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    public float gravity;
    public GameObject blast;
    public GameObject smoke;

    public float actualSpeed;
    
    private Rigidbody rb;
    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = Vector3.zero;
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
    }

    void FixedUpdate()
    {
        actualSpeed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        print(actualSpeed);
    }  

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Gravity") {
            Instantiate(blast, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
