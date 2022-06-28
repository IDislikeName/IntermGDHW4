using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject help;
    public bool paused = false;
    private static SceneMan _sm;
    public static SceneMan sm
    {
        get
        {
            if (_sm == null)
            {
                GameObject go = new GameObject("SceneMan");
                go.AddComponent<SceneMan>();
            }

            return _sm;
        }
    }

    void Awake()
    {
        _sm = this;
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Help()
    {
        help.SetActive(!help.activeInHierarchy);

    }
    public void Pause()
    {
        help.SetActive(!help.activeInHierarchy);
        paused = !paused;
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
