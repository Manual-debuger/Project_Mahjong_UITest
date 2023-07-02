using UnityEngine;

public class CameraAspectRatioAdjuster : MonoBehaviour
{
    public float targetAspectRatio = 18f / 9f; // 以18:9為目標長寬比
    public float originFOV = 55;
    public bool isSafeArea;
    private Camera mainCamera = null;

    private void Awake()
    {
        // originFOV = cam.fieldOfView;
        mainCamera = GetComponent<Camera>();
        
    }

    void Update()
    {
        var camera = mainCamera;
        Rect safeArea = Screen.safeArea;
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float scaleFactor = currentAspectRatio / targetAspectRatio;
        float viewportWidth = 1f;
        float viewportHeight = 1f;
        
        Debug.Log("scaleFactor: " + scaleFactor);
        if (scaleFactor < 1f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleFactor;
            rect.x = 0;
            rect.y = (1.0f - scaleFactor) / 2.0f;

            if (isSafeArea)
            {
                rect.x += safeArea.x / Screen.width * viewportWidth;
                rect.y += safeArea.y / Screen.height * viewportHeight;
                rect.x *= safeArea.width / Screen.width;
                rect.y *= safeArea.height / Screen.height;
            }

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / scaleFactor;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            if (isSafeArea)
            {
                rect.x += safeArea.x / Screen.width * viewportWidth;
                rect.y += safeArea.y / Screen.height * viewportHeight;
                rect.x *= safeArea.width / Screen.width;
                rect.y *= safeArea.height / Screen.height;
            }

            camera.rect = rect;
        }
    }
}