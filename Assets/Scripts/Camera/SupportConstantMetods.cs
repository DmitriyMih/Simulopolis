using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace CameraSystem
{
    public static class SupportConstantMetods
    {
        private static Vector2 DefaultResolution = new Vector2(1080, 1920);

        public static void UpdateSize(Camera camera, float orthoSize, float perspectiveSize, float WidthOrHeight)
        {
            if (camera == null) return;

            float targetAspect = GetTargetAspect();
            float horizontalFov;

            if (camera.orthographic)
            {
                //horizontalFov = CalcVerticalFov(orthoSize, 1 / targetAspect);
                float constantWidthSize = orthoSize * (targetAspect / camera.aspect);
                camera.orthographicSize = Mathf.Lerp(constantWidthSize, orthoSize, WidthOrHeight);
            }
            else
            {
                horizontalFov = CalcVerticalFov(perspectiveSize, 1 / targetAspect);
                float constantWidthFov = CalcVerticalFov(horizontalFov, camera.aspect);
                camera.fieldOfView = Mathf.Lerp(constantWidthFov, perspectiveSize, WidthOrHeight);
            }
        }

        public static void UpdateSize(CinemachineVirtualCamera virtualCamera, float orthoSize, float perspectiveSize, float WidthOrHeight)
        {
            if (virtualCamera == null)
                return;

            float targetAspect = GetTargetAspect();
            float horizontalFov;

            if (virtualCamera.m_Lens.Orthographic)
            {
                //horizontalFov = CalcVerticalFov(orthoSize, 1 / targetAspect);
                float constantWidthSize = orthoSize * (targetAspect / virtualCamera.m_Lens.Aspect);
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(constantWidthSize, orthoSize, WidthOrHeight);
            }
            else
            {
                horizontalFov = CalcVerticalFov(perspectiveSize, 1 / targetAspect);
                float constantWidthFov = CalcVerticalFov(horizontalFov, virtualCamera.m_Lens.Aspect);
                virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(constantWidthFov, perspectiveSize, WidthOrHeight);
            }
        }

        private static float GetTargetAspect()
        {
            return DefaultResolution.x / DefaultResolution.y;
        }

        private static float CalcVerticalFov(float hFovInDeg, float aspectRatio)
        {
            float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
            float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
            return vFovInRads * Mathf.Rad2Deg;
        }
    }
}