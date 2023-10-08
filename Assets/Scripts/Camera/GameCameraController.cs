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

        [SerializeField] private float fovSizeTime = 0.5f;
        [SerializeField] private List<float> fovSizeLevelItem = new() { 45f, 62.5f };

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

        private void InitializationLevel(int level)
        {
            //virtualCamera.m_Lens.FieldOfView = fovSizeLevelItem[level];
            DOTween.To(x => virtualCamera.m_Lens.FieldOfView = x, virtualCamera.m_Lens.FieldOfView, fovSizeLevelItem[level], fovSizeTime);
        }
    }
}