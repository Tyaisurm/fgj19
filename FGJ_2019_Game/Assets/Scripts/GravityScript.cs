using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public float gravity;
    private GameObject player;
    private Rigidbody prb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        prb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (player != null) {
            // player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, gravity);
            prb.AddForce((transform.position - player.transform.position).normalized * gravity);
        }
    }
}
