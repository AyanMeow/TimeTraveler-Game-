using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
//using System.String;

public class endA : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer videoPlayer;
    public string nextSceneName="";
    private void Awake()
    {
        videoPlayer.loopPointReached += test;
    }
    void Start()
    {
        Release();
        videoPlayer.Prepare();
    }

    void test(VideoPlayer videoPlayer)
    {
        Debug.Log("Video end");
        if(nextSceneName.CompareTo("Null")!=0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Release()
    {
        videoPlayer.targetTexture.Release();
        videoPlayer.targetTexture.MarkRestoreExpected();
    }
}
