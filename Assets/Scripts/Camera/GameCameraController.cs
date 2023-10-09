using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

namespace CameraSystem
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class GameCameraController : MonoBehaviour
    {
        private CinemachineVirtualCamera virtualCamera;

        [SerializeField] private int startLevel;
        public int StartLevel
        {
            get
            {
                startLevel = Mathf.Clamp(startLevel, 0, fovSizeLevelItem.Count - 1);
                return startLevel;
            }
        }

        [Serializable]
        private class CameraInfo
        {
            public float OrthoSize;
            public float PerspectiveSize;

            public CameraInfo(float orthoSize, float perspectiveSize)
            {
                this.OrthoSize = orthoSize;
                this.PerspectiveSize = perspectiveSize;
            }
        }

        [SerializeField] private float fovSizeTime = 0.5f;
        [SerializeField] private List<CameraInfo> fovSizeLevelItem = new() { new(3f, 45f), new(5.5f, 80f), new(7.5f, 75f) };

        private void Awake()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }
        private void Start()
        {
            Initialization();
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            Initialization();
        }
#endif

        private void Initialization()
        {
            InitializationLevel(StartLevel);
        }

        private void InitializationLevel(int level)
        {
            if (virtualCamera == null) return;

            if (virtualCamera.m_Lens.Orthographic)
                DOTween.To(x => virtualCamera.m_Lens.FieldOfView = x, virtualCamera.m_Lens.FieldOfView, fovSizeLevelItem[level].OrthoSize, fovSizeTime);
            else
                DOTween.To(x => virtualCamera.m_Lens.FieldOfView = x, virtualCamera.m_Lens.FieldOfView, fovSizeLevelItem[level].PerspectiveSize, fovSizeTime);
        }
    }
}