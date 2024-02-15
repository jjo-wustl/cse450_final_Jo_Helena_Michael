using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class SkiObstacle : MonoBehaviour
    {
        public static int restartCount;

        private void Start()
        {
            restartCount = 0;
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.GetComponent<SkiControls>())
            {
                restartCount++;
                print(restartCount.ToString());
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

