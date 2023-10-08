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
        [SerializeField] private List<CameraInfo> fovSizeLevelItem = new() { new(3f, 45f), new(5.5f, 80f) };

        private void Awake()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
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
            if (gameObject.activeSelf)
                StartCoroutine(SetField(fovSizeLevelItem[level].OrthoSize, fovSizeLevelItem[level].PerspectiveSize));

            //if (virtualCamera == null) return;
            //if (virtualCamera.m_Lens.Orthographic)
            //    DOTween.To(x => virtualCamera.m_Lens.FieldOfView = x, virtualCamera.m_Lens.FieldOfView, fovSizeLevelItem[level].orthoSize, fovSizeTime);
            ////.OnComplete(() => isActiveField = false);
            //else
            //    DOTween.To(x => virtualCamera.m_Lens.FieldOfView = x, virtualCamera.m_Lens.FieldOfView, fovSizeLevelItem[level].perspectiveSize, fovSizeTime);
            ////.OnComplete(() => isActiveField = false);
        }

        private IEnumerator SetField(float targetOrthoSize, float targetPerspectiveSize)
        {
            float time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime;
            }

            Debug.Log("Set Field");
            yield return null;
        }
    }
}