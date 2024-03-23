using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code { 
    public class EndGame : MonoBehaviour
    {
        [SerializeField] public int sceneCount;

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<SkiControls>())
            {
                Timer timer = FindObjectOfType<Timer>();
                if (timer)
                {
                    timer.SaveBestTime();
                    print("called save best time");
                }

                int scene = (SceneManager.GetActiveScene().buildIndex + 1) % 2;
                //print("scene number attempt: " + scene);
                SceneManager.LoadScene(scene);

            }
            
        }
    }
}