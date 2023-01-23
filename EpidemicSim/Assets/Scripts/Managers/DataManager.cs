using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene currentScene;
    string sceneName;
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        //DontDestroyOnLoad(this.gameObject);
        //UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
