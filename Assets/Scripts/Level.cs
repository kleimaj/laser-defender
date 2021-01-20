using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour {

    int numScenes;
    int currentSceneIndex;

    private void Start() {
        numScenes = SceneManager.sceneCountInBuildSettings;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene() { 
        if (numScenes == currentSceneIndex + 1) {
            SceneManager.LoadScene(0);
        }
        else {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
