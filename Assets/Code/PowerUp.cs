using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class PowerUp : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            SkiControls skiController = other.gameObject.GetComponent<SkiControls>();
            if (skiController)
            {
                skiController.power_up = true;
            }
        }
    }
}
