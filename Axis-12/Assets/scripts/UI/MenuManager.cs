using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject buttons;
    public GameObject options;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Options()
    {
        buttons.SetActive(!buttons.activeSelf);
        options.SetActive(!options.activeSelf);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
