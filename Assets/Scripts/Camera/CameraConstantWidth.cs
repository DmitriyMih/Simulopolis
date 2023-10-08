using UnityEngine;

public class CameraConstantWidth : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(720, 1280);
    [Range(0f, 1f)] public float WidthOrHeight = 0;

    private Camera componentCamera;
    
    [SerializeField] private float initialOrthoSize;
    [SerializeField] private float initialFovSize;

    private float targetAspect;
    private float horizontalFov = 120f;

    private void Awake()
    {
        componentCamera = GetComponent<Camera>();
        targetAspect = DefaultResolution.x / DefaultResolution.y;

        //initialOrthoSize = componentCamera.orthographicSize;
        //initialFovSize = componentCamera.fieldOfView;

        horizontalFov = CalcVerticalFov(initialFovSize, 1 / targetAspect);
    }

    public void SetSize(float orthoSize, float perspectiveSize)
    {
        initialOrthoSize = orthoSize;
        initialFovSize = perspectiveSize;
    }

    private void Update()
    {
        if (componentCamera.orthographic)
        {
            float constantWidthSize = initialOrthoSize * (targetAspect / componentCamera.aspect);
            componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialOrthoSize, WidthOrHeight);
        }
        else
        {
            float constantWidthFov = CalcVerticalFov(horizontalFov, componentCamera.aspect);
            componentCamera.fieldOfView = Mathf.Lerp(constantWidthFov, initialFovSize, WidthOrHeight);
        }
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;

        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);

        return vFovInRads * Mathf.Rad2Deg;
    }
}