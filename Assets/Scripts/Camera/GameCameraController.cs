using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

namespace CameraSystem
{
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    [RequireComponent(typeof(CameraConstantWidth))]
    public class GameCameraController : MonoBehaviour
    {
        private CinemachineVirtualCamera virtualCamera;
        private CameraConstantWidth cameraConstant;

        [SerializeField] private int startLevel;
        public int StartLevel
        {
            get
            {
                startLevel = Mathf.Clamp(startLevel, 0, fovSizeLevelItem.Count - 1);
                return startLevel;
            }
        }

        private class CameraInfo
        {
            public float orthoSize;
            public float perspectiveSize;

            public CameraInfo(float orthoSize, float perspectiveSize)
            {
                this.orthoSize = orthoSize;
                this.perspectiveSize = perspectiveSize;
            }
        }

        [SerializeField] private float fovSizeTime = 0.5f;
        [SerializeField] private List<CameraInfo> fovSizeLevelItem = new() { new(3f, 45f), new(5.5f, 80f) };

        private void Awake()
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
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            InitializationLevel(StartLevel);
        }

        bool isActiveField = false;
        private void InitializationLevel(int level)
        {
            //virtualCamera.m_Lens.FieldOfView = fovSizeLevelItem[level];

            isActiveField = true;

            if (virtualCamera.m_Lens.Orthographic)
                DOTween.To(x => virtualCamera.m_Lens.FieldOfView = x, virtualCamera.m_Lens.FieldOfView, fovSizeLevelItem[level].orthoSize, fovSizeTime).OnComplete(() => isActiveField = false);
            else
                DOTween.To(x => virtualCamera.m_Lens.FieldOfView = x, virtualCamera.m_Lens.FieldOfView, fovSizeLevelItem[level].perspectiveSize, fovSizeTime).OnComplete(() => isActiveField = false);

            cameraConstant.SetSize(fovSizeLevelItem[level].orthoSize, fovSizeLevelItem[level].perspectiveSize);
        }
    }
}