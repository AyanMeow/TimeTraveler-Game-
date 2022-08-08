using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Texture image;
    private static bool start=false;
    private float alpha=0f;
    private bool hasLoad=false;

    // Start is called before the first frame update
    private void OnGUI() {
        if(start)
        {
            alpha+=0.4f*Time.deltaTime;   
            if(alpha>=1f)
            {
                if(!hasLoad)
                {
                    SceneManager.LoadScene("4.Scene01");
                    start=false;
                    hasLoad=true;
                }
                
            }
        }
        GUI.color=new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha);
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),image);
    }

    public void changeStatu()
    {
        start=true;
        Debug.Log("pressed Button");
    }

    public void OnExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
