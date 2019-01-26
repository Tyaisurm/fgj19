using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEffectScript : MonoBehaviour
{
    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 40;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3 (0.005F, 0.005F, 0.005F);
        timer--;

        if (timer == 0) {
            Destroy(gameObject);
        }
    }
}
