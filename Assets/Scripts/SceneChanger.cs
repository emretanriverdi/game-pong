using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public string sceneToLoad = "";
    public float seconds = 3.0f;

    // Use this for initialization
    void Start() {
        Invoke("OpenNewScene", seconds);
    }

    void OpenNewScene() {
        SceneManager.LoadScene(sceneToLoad);
    }
}