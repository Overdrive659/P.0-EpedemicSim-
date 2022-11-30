using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerosolScript : MonoBehaviour
{
    public float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = Convert.ToInt32(timer % 60);
        Debug.Log(seconds);

        transform.localScale = new Vector3(seconds, seconds, seconds);
    }
}
