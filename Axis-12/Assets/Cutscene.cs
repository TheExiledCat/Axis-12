using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class Cutscene : MonoBehaviour
{
    public RawImage img;
    public VideoPlayer source;

    private void Start()
    {
        source.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        source.playOnAwake = false;
        source.loopPointReached += EndReached;
    }
    private void Update()
    {
        if (source.isPrepared)
            img.texture = source.texture;
        

    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
