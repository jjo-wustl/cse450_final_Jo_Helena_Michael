using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Code
{
    public class SkiControls : MonoBehaviour
    {
        public static SkiControls instance;

        public TMP_Text collisionUI;
        public int collisionsLeft;
        private Vector3 velocity = Vector3.zero;
        public float smoothTime = 3f;
        public bool power_up = false;
        public float timeElapsed;
        public bool isPaused;

        private void Start()
        {
            instance = this;
            collisionsLeft = 3;

        }

        // Update is called once per frame
        void Update()
        {
            if (isPaused)
            {
                return;
            }
            // check esc key for menu
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                MenuController.instance.ShowMainMenu();
            }

            if (power_up)
            {
                transform.position += new Vector3(0, -0.01f, 0);
                timeElapsed += Time.deltaTime;
                if(timeElapsed > 1f)
                {
                    power_up = false;
                    timeElapsed = 0;
                }
            }
            
            //move left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.eulerAngles = (Vector3.forward * (Mathf.Atan2(0.1f,0.5f) * Mathf.Rad2Deg - 90))/3f;
                transform.position += Vector3.left * Time.fixedDeltaTime;
            }
            
            //move right
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.eulerAngles = (Vector3.forward * (Mathf.Atan2(0.1f, 0.5f) * Mathf.Rad2Deg + 90))/3f;
                transform.position += Vector3.right * Time.fixedDeltaTime;
            }

            else
            {
                transform.eulerAngles = Vector3.forward;
            }
            
            //speed up (will change later)
            if (Input.GetKey(KeyCode.DownArrow))
            {
                float speedIncrease = 0.009f;
                Vector3 direction = -transform.up;
                transform.position += direction * speedIncrease;
            }

            collisionUI.text = "Collisions Left: " + collisionsLeft.ToString();
        }
  
    }
}