using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CameraSystem
{
    public enum DragDirection
    {
        Left,
        Right
    }

    public class CameraRotator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform cameraGroup;
        [SerializeField] private float rotationSpeed;

        private float lastTouchX;
        bool isTouch = false;

        private void Update()
        {
            if (isTouch)
            {
                Vector3 touch = Input.mousePosition;

                float touchDelta = lastTouchX - touch.x;
                cameraGroup.Rotate(Vector3.up, -touchDelta * rotationSpeed);
                lastTouchX = touch.x;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isTouch = true;
            lastTouchX = eventData.position.x;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isTouch = false;
        }
    }
}