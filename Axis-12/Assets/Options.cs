using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Options : MonoBehaviour
{
    AudioSource source;
    public AudioClip menu;
    public AudioClip game;
    bool Sound = true;
    float volume = 0.3f;
    private void Awake()
    {
        source = Camera.main.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }
    public void changeSound()
    {
        
       
        Sound = !Sound;
        Debug.Log(Sound);
    }
    private void Update()
    {
        source = Camera.main.GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            source.clip = menu;
        }
        else
        {
            source.clip = game;
        }
        if (!Sound)
            source.volume = 0f;
        else if (Sound)
            source.volume = volume;
        if (!source.isPlaying)
        source.Play();
       
    }

}
