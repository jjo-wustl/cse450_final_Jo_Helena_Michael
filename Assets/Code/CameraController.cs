using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code{
    public class CameraController : MonoBehaviour
    {
        //Outlet
        public Transform target;
        
        //Configuration
        public Vector3 verticalOffset;
        public float smoothness;
        
        //State Tracking
        Vector3 _velocity;

        private void Start()
        {
            if (target)
            {
                verticalOffset = transform.position - target.position;

            }
        }

        void Update()
        {
            if (target)
            {
                Vector3 targetPosition = target.position + verticalOffset;
                targetPosition.x = transform.position.x;
                transform.position = Vector3.SmoothDamp(
                    transform.position,
                    targetPosition,
                    ref _velocity,
                    smoothness);
            }
        }

    }
}