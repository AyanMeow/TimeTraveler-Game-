using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrach : MonoBehaviour
{
    public GameObject mask;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(Generate());
        }
    }

    private IEnumerator Generate()
    {
        int tempCount = 0;
        for (int i = 0; i < 100000; i++)
        {
            if (tempCount <= 5000)
            {
                if(transform.position.z!=86)
                {
                    Debug.Log(transform.position.z);
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos.z=86;
                    Instantiate(mask,pos,Quaternion.identity,parent);
                }
                tempCount++;
            }
            else
            {
                tempCount = 0;
                yield return new WaitForEndOfFrame();
                if(transform.position.z!=86)
                {
                    Debug.Log(transform.position.z);
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos.z=86;
                    Instantiate(mask,pos,Quaternion.identity,parent);
                }
            }
        }
    }

}
