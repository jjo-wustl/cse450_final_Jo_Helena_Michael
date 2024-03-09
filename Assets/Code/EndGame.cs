using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code { 
    public class EndGame : MonoBehaviour
    {
        private int[] sceneIndices;
        private static int sceneCount;

        private void Awake()
        {
            sceneIndices = new int[2];
            sceneIndices[0] = 0;
            sceneIndices[1] = 1;
            sceneCount = 0;
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<SkiControls>())
            {
                print("Scene index: " + SceneManager.GetActiveScene().buildIndex);
                int scene = sceneCount % 2;
                sceneCount++;
                SceneManager.LoadScene(sceneBuildIndex: sceneIndices[sceneCount]);
                
            }
            
        }
    }
}