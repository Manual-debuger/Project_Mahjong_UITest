using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aspectCamera : MonoBehaviour
{
    public float baseWidth = 1024;
    public float baseHeight = 768;
    public float baseOrthographicSize = 390;

    void Update()
    {

        float newOrthographicSize = (float)Screen.height / (float)Screen.width * this.baseWidth / this.baseHeight * this.baseOrthographicSize;
        GetComponent<Camera>().orthographicSize = Mathf.Max(newOrthographicSize, this.baseOrthographicSize);
    }
}
