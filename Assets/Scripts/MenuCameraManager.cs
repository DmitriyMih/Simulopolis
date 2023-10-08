using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSystem
{
    public enum CameraType
    {
        MenuCamera,
        GameCamera
    }

    [Serializable]
    public class CameraItem
    {
        public CameraType CameraType;
        public Camera camera;
    }

    public class MenuCameraManager : MonoBehaviour
    {
        [SerializeField] private CameraType cameraType;
        [SerializeField] private List<CameraItem> cameraItems = new();

        Camera tempCamera;

        private void Awake()
        {
            SetCamera();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            SetCamera();
        }
#endif

        private void SetCamera()
        {
            if (cameraItems.Exists(x => x.CameraType == cameraType))
            {
                Camera camera = cameraItems.Find(x => x.CameraType == cameraType).camera;

                if (camera != null)
                {
                    if (tempCamera != null && tempCamera != camera)
                        tempCamera.gameObject.SetActive(false);
                
                    camera.gameObject.SetActive(true);
                    tempCamera = camera;
                }
            }
        }
    }
}