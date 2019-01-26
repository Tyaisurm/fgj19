using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public int rotateSpeed;
    public bool randomColor;
    private Renderer m_Renderer;
    SphereCollider gravityBound;

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        if (randomColor) {
            m_Renderer.material.color = new Color(Random.Range(0, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }  
}
