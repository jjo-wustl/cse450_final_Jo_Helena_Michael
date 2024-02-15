using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class SkiObstacle : MonoBehaviour
    {
        //public static int restartCount;

        private void Start()
        {
            //restartCount = PlayerPrefs.GetInt("restartCount");
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.GetComponent<SkiControls>())
            {
                //restartCount++;
                //PlayerPrefs.SetInt("Count", restartCount);
                //print(PlayerPrefs.GetInt("restartCount"));
                SkiControls.instance.restartCounter++;
                PlayerPrefs.SetInt("restartCounter", SkiControls.instance.restartCounter);
                print(SkiControls.instance.restartCounter);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}

