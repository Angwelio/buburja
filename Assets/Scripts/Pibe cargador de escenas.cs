using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pibecargadordeescenas : MonoBehaviour
{
    //public string escena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void escenacambio(string escena){
        SceneManager.LoadScene(escena);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            // Stop play mode in the Unity Editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Close the application in a build
            Application.Quit();
        #endif
    }
}
