using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordman : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0))
        {
            SelectUnit();
        }
        
    }

    void SelectUnit()
    {
        GameObject objWithTag = GameObject.FindWithTag("Swordman");

        // 检查是否找到了对象
        if (objWithTag != null)
        {
            // 找到了对象，可以进行相应的操作
            Debug.Log("找到了对象：" + objWithTag.name);
        }
    }
}
