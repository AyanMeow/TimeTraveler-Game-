using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float pos_z;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos_z);
        transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);
    }
}
