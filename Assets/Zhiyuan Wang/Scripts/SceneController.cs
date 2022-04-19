using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void ChangeScene()
    {

        Invoke("InvokeScene", 0.5f);
    }

    public void QuitGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StartScene()
    {
        Invoke("InvokeSceneStart", 0.5f);
    }

    public void InvokeSceneMenu()
    {
        Invoke("Menu", 0.5f);
    }

    void InvokeScene()
    {
        SceneManager.LoadScene("ZhiyuanWangScene");
    }

    void InvokeSceneStart()
    {
        SceneManager.LoadScene("Start");
    }

    void InvokeQuit()
    {
        Application.Quit();
    }
}
