﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathManager : MonoBehaviour
{
    public void Resume()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        {
            Application.Quit();    
        }
    }
}
