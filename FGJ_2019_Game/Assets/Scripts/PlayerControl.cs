using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    public float gravity;
    public GameObject blast;
    public GameObject smoke;
    public GameObject destination;
    public GameObject camera;
    public Text speedtext;

    public float actualSpeed;
    
    private Rigidbody rb;
    private Vector3 lastPosition;
    private GameObject arrow;
    private Vector3 lookVector;

    public static int lorePhase;
    public TextAsset lore;
    private string[] passages;
    public Text loretext;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = Vector3.zero;

        arrow = this.gameObject.transform.GetChild(1).gameObject;

        passages = lore.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(smoke, transform.position - transform.up / 3, transform.rotation);

        lookVector = destination.transform.position - arrow.transform.position;
        arrow.transform.LookAt(camera.transform.position, lookVector);
    }

    void FixedUpdate()
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

        if (Input.GetKey("space")) {
            rb.velocity = rb.velocity * 0.9F;
        }

        actualSpeed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }  

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Gravity") {
            if (actualSpeed > 0.04 || other.tag == "Sun") {
                Instantiate(blast, transform.position, transform.rotation);
                Destroy(gameObject);
            } else {
                if (other.transform.position == destination.transform.position) {
                    ActivateLore();
                }
            }
        }
    }

    public void ActivateLore () {

        panel.SetActive(true);
        string totext = "";

        foreach (string pass in passages) {
            if (pass.StartsWith(lorePhase.ToString())) {
                totext = totext + pass.Substring(1) + "\n\n";
            }
        }

        loretext.text = totext;

        lorePhase++;

        gameObject.SetActive(false);
    }
}
