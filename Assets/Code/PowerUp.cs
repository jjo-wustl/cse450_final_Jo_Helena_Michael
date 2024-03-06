using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class PowerUp : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            print("here");
            SkiControls skiController = other.gameObject.GetComponent<SkiControls>();
            if (skiController)
            {
                skiController.vel_power -= 0.01f;
            }
        }
    }
}
