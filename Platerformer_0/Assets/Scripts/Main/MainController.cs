using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static MainController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        //Application.Quit();

        gameObject.SetActive(false);

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
    }
}
