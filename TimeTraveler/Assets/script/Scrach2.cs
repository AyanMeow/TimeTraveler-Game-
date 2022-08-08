using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
//using System.String;

public class Scrach2 : MonoBehaviour
{
    public GameObject mask;
    public SpriteRenderer cover;
    public RawImage coverImage;
    public Transform parent;
    public float position_z;
    public VideoPlayer videoPlayer;
    public string nextSceneName="";

    private int count=0;
    private bool startfade=false;
    private bool videoAlive=false;
    private float alpha=1f;
    private Color newColor;
    private bool hasLoad=false;

    // Start is called before the first frame update

    private void Awake() 
    {
        videoPlayer.loopPointReached += nextScene;
    }

    void Start()
    {
        Release();
        videoPlayer.Prepare();
        count=0;
        //StartCoroutine(loadSceneAsync());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)&(!videoAlive))
        {
            if(transform.position.z!=position_z)
                {
                    count++;
                    Debug.Log(transform.position.z);
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos.z=position_z;
                    Instantiate(mask,pos,Quaternion.identity,parent);
                    if(count>=250)
                    {
                        Debug.Log("clone has reached stander(250)");
                        startfade=true;
                    }
                }
        }

        if(startfade&(!videoAlive))
        {
            //Release();
            videoPlayer.Play();
            //System.Threading.Thread.Sleep(1000);
            newColor=new Color(coverImage.color.r,coverImage.color.g,coverImage.color.b,0);
            coverImage.color=newColor;
            videoAlive=true;
        }

        if(startfade)
        {
            alpha-=0.4f*Time.deltaTime;   
            if(alpha<=0f)
            {
                startfade=false;
                Destroy(parent.gameObject);
            }
            newColor=new Color(cover.color.r,cover.color.g,cover.color.b,alpha);
            cover.color=newColor;
        }

        //videoPlayer.loopPointReached += nextScene;
    }

    void nextScene(VideoPlayer videoPlayer2)
    {
        Debug.Log("Video end");
        if(!hasLoad)
        {
            if(nextSceneName.CompareTo("Null")!=0)
            {
                SceneManager.LoadScene(nextSceneName);
                //Application.LoadLevelAsync(nextSceneName);
                hasLoad=true;
            }
        }
        
    }

    public void Release()
    {
        videoPlayer.targetTexture.Release();
        videoPlayer.targetTexture.MarkRestoreExpected();
    }

    IEnumerator loadSceneAsync()
    {
        int disableProgress = 0;
        int toProgress = 0;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);
        op.allowSceneActivation = false;
         while (op.progress < 0.9f)
        {

            toProgress = (int)(op.progress * 100);
            while (disableProgress < toProgress)
            {
                ++disableProgress;
                yield return new WaitForEndOfFrame();
            }
        }
        op.allowSceneActivation = true;

    }
}
