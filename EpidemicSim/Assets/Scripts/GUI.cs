using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    private bool isShowing = true;
    [SerializeField] private GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        //canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            if (isShowing)
            {
                isShowing = false;
            }
            else
            {
                isShowing = true;
            }
        }

        if (isShowing)
        {
            
        }

    }

}
