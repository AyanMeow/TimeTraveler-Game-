using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour
{
    public Texture image;
    private float alpha=1f;
    // Start is called before the first frame update
    private void OnGUI() {
        if(true)
        {
            alpha-=0.3f*Time.deltaTime;   
            if(alpha<=0f)
            {

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
