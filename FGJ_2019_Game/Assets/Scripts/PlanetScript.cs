using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public int rotateSpeed;
    public float gravity;
    public bool randomColor;
    private Renderer m_Renderer;
    private GameObject player;
    SphereCollider gravityBound;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        if (randomColor) {
            m_Renderer.material.color = new Color(Random.Range(0, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        }

        gravityBound = gameObject.AddComponent<SphereCollider>();
        gravityBound.isTrigger = true;
        gravityBound.radius = 2;
        
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);

        //player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, gravity) * (1 / Vector3.Distance(transform.position, player.transform.position));
    }

    private void OnTriggerStay(Collider other)
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, gravity);
    }
}
