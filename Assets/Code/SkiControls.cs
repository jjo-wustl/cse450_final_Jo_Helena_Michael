using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class SkiControls : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //move left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-0.1f, 0, 0);
            }
            
            //move right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(0.1f, 0, 0);
            }
        }
    }
}