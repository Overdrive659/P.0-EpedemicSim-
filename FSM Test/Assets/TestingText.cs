using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class TestingText : MonoBehaviour
{
    [SerializeField] InputField TextField;
    [SerializeField] VarHolder VarHolder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        string[] timeArray = TextField.text.Split(':');
        Debug.Log(timeArray[0]);
        Debug.Log(timeArray[1]);
        VarHolder.simHours = int.Parse(timeArray[0]);
        VarHolder.simMinutes = int.Parse(timeArray[1]);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
