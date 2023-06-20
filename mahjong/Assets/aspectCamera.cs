using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aspectCamera : MonoBehaviour
{
    public float deviceWidth;
    public float deviceHeight;
    public float aspectRatio;
    public Camera mainCamera;

    private void Awake()
    {
        aspectRatio = deviceWidth / deviceHeight;
    }

    private void Update()
    {
        deviceWidth = Screen.width;
        deviceHeight = Screen.height;
        aspectRatio = deviceWidth / deviceHeight;
        float targetAspectRatio = 1792f / 828f;
        float baseFOV = 55f;
        float extraWidth = 0f;
        float extraHeight = 0f;

        if (aspectRatio > targetAspectRatio)
        {
            // ??��?�����??�A�ݭn�K�[��?�b���k
            extraWidth = deviceHeight * targetAspectRatio - deviceWidth;
        }
        else if (aspectRatio < targetAspectRatio)
        {
            // ??��?�����?���A�ݭn�K�[��?�b�W�U
            extraHeight = deviceWidth / targetAspectRatio - deviceHeight;
        }

        Debug.Log(deviceWidth);
        Debug.Log(deviceHeight);
        float targetFOV = baseFOV * (targetAspectRatio / aspectRatio);
        mainCamera.fieldOfView = targetFOV;

        // ���u�ݭn�K�[����?�j�p?�����?���S?
        mainCamera.rect = new Rect(
            extraWidth / (2f * deviceWidth),
            extraHeight / (2f * deviceHeight),
            1f - extraWidth / deviceWidth,
            1f - extraHeight / deviceHeight
        );

        // �b���󪺭I���W�K�[��?�ĪG
        mainCamera.backgroundColor = Color.black;
    }
}