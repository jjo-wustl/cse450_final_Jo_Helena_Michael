using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
    public class SkiObstacle : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            SkiControls skiController = other.gameObject.GetComponent<SkiControls>();
            if(skiController)
            {
                skiController.collisionsLeft--;
                if(skiController.collisionsLeft == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
       
        
}
}

