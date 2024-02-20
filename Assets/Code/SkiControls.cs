using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Code
{
    public class SkiControls : MonoBehaviour
    {
        public TMP_Text collisionUI;
        public int collisionsLeft;
       
        private void Start()
        {
            collisionsLeft = 5;
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

            collisionUI.text = "Collisions Left: " + collisionsLeft.ToString();
        }
    }
}