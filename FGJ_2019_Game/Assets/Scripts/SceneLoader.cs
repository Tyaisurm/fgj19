﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r")) {
            SceneManager.LoadScene(scene.name);
        }
    }

    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
}
