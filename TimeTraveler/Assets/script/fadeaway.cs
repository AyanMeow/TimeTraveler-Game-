using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeaway : MonoBehaviour
{
    public Texture image;
    private static bool start=false;
    private float alpha=0f;
    private bool hasLoad=false;
    // Start is called before the first frame update
    private void OnGUI() {
        if(Input.GetMouseButtonDown(0))
        {
            print("鼠标左键按下");
            start=true;
        }
        if(start)
        {
            alpha+=0.4f*Time.deltaTime;   
            if(alpha>=1f)
            {
                if(!hasLoad)
                {
                    SceneManager.LoadScene("2.start");
                    start=false;
                    hasLoad=true;
                }
                
            }
        }
        GUI.color=new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha);
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),image);
        
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
