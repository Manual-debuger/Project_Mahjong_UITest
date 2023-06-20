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
            // ??的?高比例??，需要添加黑?在左右
            extraWidth = deviceHeight * targetAspectRatio - deviceWidth;
        }
        else if (aspectRatio < targetAspectRatio)
        {
            // ??的?高比例?窄，需要添加黑?在上下
            extraHeight = deviceWidth / targetAspectRatio - deviceHeight;
        }

        Debug.Log(deviceWidth);
        Debug.Log(deviceHeight);
        float targetFOV = baseFOV * (targetAspectRatio / aspectRatio);
        mainCamera.fieldOfView = targetFOV;

        // 根据需要添加的黑?大小?整相机的?野范?
        mainCamera.rect = new Rect(
            extraWidth / (2f * deviceWidth),
            extraHeight / (2f * deviceHeight),
            1f - extraWidth / deviceWidth,
            1f - extraHeight / deviceHeight
        );

        // 在相机的背景上添加黑?效果
        mainCamera.backgroundColor = Color.black;
    }
}