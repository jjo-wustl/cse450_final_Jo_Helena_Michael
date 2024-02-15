using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Code
{
    public class SkiControls : MonoBehaviour
    {
        public static SkiControls instance;

        public int restartCounter;
        public TMP_Text restartUI;
       
        private void Awake()
        {
            instance = this;
          
        }
        private void Start()
        {
            restartCounter = PlayerPrefs.GetInt("restartCounter");
        }

        // Update is called once per frame
        void Update()
        {
            //move left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-0.01f, 0, 0);
            }
            
            //move right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.01f, 0, 0);
            }
            
            //speed up (will change later)
            if (Input.GetKey(KeyCode.DownArrow))
            {
            }

            restartUI.text = restartCounter.ToString();
        }
    }
}