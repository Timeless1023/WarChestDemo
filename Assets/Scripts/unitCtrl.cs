using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mapclick();
    }

    void mapclick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("鼠标左键被按下！");
        }
    }
}
