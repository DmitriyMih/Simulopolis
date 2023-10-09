using UnityEngine;
using Cinemachine;

namespace CameraSystem
{
    [RequireComponent(typeof(Camera))]
    public class StaticCameraConstantWidth : MonoBehaviour
    {
        private CinemachineVirtualCamera virtualCamera;

        [Range(0f, 1f)] public float WidthOrHeight = 0.5f;

        private Camera componentCamera;

        [SerializeField] private float initialOrthoSize = 3f;
        [SerializeField] private float initialFovSize = 45f;

        [SerializeField] private bool isActive;

        private void Awake()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            componentCamera = GetComponent<Camera>();
        }

        private void Start()
        {
            UpdateSize();
        }

        [ContextMenu("Update Size")]
        private void UpdateSize()
        {
            if (virtualCamera != null)
                SupportConstantMetods.UpdateSize(componentCamera, virtualCamera, initialOrthoSize, initialFovSize, WidthOrHeight);
            else
                SupportConstantMetods.UpdateSize(componentCamera, initialOrthoSize, initialFovSize, WidthOrHeight);
        }

        private void Update()
        {
            if (isActive)
                UpdateSize();
        }
    }
}