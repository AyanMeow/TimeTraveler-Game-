using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{

    private bool hasLoad=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!hasLoad)
            {
                Debug.Log("ESC down");
                SceneManager.LoadScene("3.start_2");
                hasLoad=true;
            }
        }
    }
}
