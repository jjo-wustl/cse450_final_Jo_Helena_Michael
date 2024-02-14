using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code{
    public class CameraController : MonoBehaviour
    {
        //Outlet
        public Transform target;
        public float verticalOffset;

        void Update()
        {
            if (target)
            {
                transform.position += new Vector3(0, verticalOffset, 0);
            }
        }

    }
}