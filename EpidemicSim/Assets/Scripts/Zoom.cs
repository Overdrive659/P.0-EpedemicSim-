using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float ScrollSpeed = 0.1f;
    private Camera ZoomCamera;



    void Start()
    {
        ZoomCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (ZoomCamera.orthographic) 
        {
            ZoomCamera.orthographicSize -= Input.GetAxisRaw("Mouse ScrollWheel") * ScrollSpeed;
        }
    }
}
