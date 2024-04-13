using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class SkiObstacle : MonoBehaviour
    {
        public GameObject explosionPrefab; // reference the explosion prefab

        void OnCollisionEnter2D(Collision2D other)
        {
            SkiControls skiController = other.gameObject.GetComponent<SkiControls>();
            if (skiController)
            {
                skiController.collisionsLeft--;


                // Instantiate the explosion when the skier collides with an obstacle
                if (explosionPrefab != null)
                {
                    Instantiate(explosionPrefab, new Vector3(other.contacts[0].point.x, other.contacts[0].point.y, 0), Quaternion.identity);
                    Debug.Log("Collision with obstacle detected");
                }


                if (skiController.collisionsLeft == 0)
                {
                    // I think we shouldn't save best time is the user didn't make it to finish line
                    Timer timer = FindObjectOfType<Timer>();
                    if (timer)
                    {
                        timer.SaveBestTime();
                    }
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

    } 
        
}


