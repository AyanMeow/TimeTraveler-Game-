using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DropSkip : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private bool hasLoad=false;
    // Start is called before the first frame update
    void Start()
    {
        Release();
        videoPlayer.Prepare();
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!hasLoad)
            {
                SceneManager.LoadScene("3.start_2");
                hasLoad=true;
            }
            
        }
    }

    public void Release()
    {
        videoPlayer.targetTexture.Release();
        videoPlayer.targetTexture.MarkRestoreExpected();
    }
}
