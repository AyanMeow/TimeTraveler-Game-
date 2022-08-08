using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class videoSwitch : MonoBehaviour
{
    public Texture image;
    public bool needFadeaway=false;
    public RawImage videoLoadImage;
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    private static bool start=false;
    private float alpha=0f;
    private Color newColor;
    private bool hasLoad=false;

    private void OnGUI() 
    {  
        if(start)
        {
            alpha+=0.6f*Time.deltaTime;   
            if(alpha>=1f)
            {
                start=false;
                alpha=0f;
            }
        }
        GUI.color=new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha);
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),image);
    }

    public void buttonClick()
    {
        if(!(videoPlayer.isPlaying))
        {
            start=needFadeaway;
            newColor=new Color(videoLoadImage.color.r,videoLoadImage.color.g,videoLoadImage.color.b,1);
            videoLoadImage.color=newColor;
            Debug.Log("vide2 ready to play");
            videoPlayer.Play();
        }
    }

        public void Release()
    {
        videoPlayer.targetTexture.Release();
        videoPlayer.targetTexture.MarkRestoreExpected();
    }

    // Start is called before the first frame update
    void Start()
    {
        Release();
        videoPlayer.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        videoPlayer.loopPointReached+=nextScene;
    }

    void nextScene(VideoPlayer videoPlayer)
    {
        Debug.Log("Video end");
        if(!hasLoad)
        {
            if(nextSceneName.CompareTo("Null")!=0)
            {
                SceneManager.LoadScene(nextSceneName);
            }
            hasLoad=true;
        }
        
    }

}
