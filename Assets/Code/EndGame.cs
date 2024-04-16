using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code { 
    public class EndGame : MonoBehaviour
    {
        //[SerializeField] public int sceneCount;
        private const int SCENE_COUNT = 4;

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

                if (PlayerPrefs.GetInt("sceneReached") < SCENE_COUNT - 1)
                {
                    PlayerPrefs.SetInt("sceneReached", PlayerPrefs.GetInt("sceneReached") + 1);
                }

                int scene = (SceneManager.GetActiveScene().buildIndex + 1) % SCENE_COUNT;
                //print("scene number attempt: " + scene);
                SceneManager.LoadScene(scene);

            }
            
        }
    }
}