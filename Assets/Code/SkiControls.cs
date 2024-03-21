using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Code
{
    public class SkiControls : MonoBehaviour
    {
        public TMP_Text collisionUI;
        public int collisionsLeft;
        private Vector3 velocity = Vector3.zero;
        public float smoothTime = 3f;
        public float vel_power = 0;

        private void Start()
        {
            collisionsLeft = 5;

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += new Vector3(0, vel_power, 0);
            print(vel_power);
            //move left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.eulerAngles = (Vector3.forward * (Mathf.Atan2(0.1f,0.5f) * Mathf.Rad2Deg - 90))/3f;
                transform.position += new Vector3(-0.01f,0, 0);
            }
            
            //move right
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.eulerAngles = (Vector3.forward * (Mathf.Atan2(0.1f, 0.5f) * Mathf.Rad2Deg + 90))/3f;
                transform.position += new Vector3(0.01f, 0, 0);
            }

            else
            {
                transform.eulerAngles = (Vector3.forward);
            }
            
            //speed up (will change later)
            if (Input.GetKey(KeyCode.DownArrow))
            {
            }

            collisionUI.text = "Collisions Left: " + collisionsLeft.ToString();
        }
  
    }
}