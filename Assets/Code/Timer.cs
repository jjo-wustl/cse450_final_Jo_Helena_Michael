using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class Timer : MonoBehaviour
    {
        public Sprite[] numberSprites = new Sprite[10];
        public Image[] digitDisplays;

        private float elapsedTime = 0f; // Tracks the elapsed time
        public bool timerIsRunning = false;

        void Start()
        {
            // Optionally start the timer on start, or you can start it based on some event
            timerIsRunning = true;
        }

        void Update()
        {
            if (timerIsRunning)
            {
                elapsedTime += Time.deltaTime;
                UpdateDisplay();
            }
        }

        private void UpdateDisplay()
        {
            int time = Mathf.FloorToInt(elapsedTime);

            // Assuming you want to display time in MM:SS format and have 4 digitDisplays
            int minutes = time / 60;
            int seconds = time % 60;

            if (digitDisplays.Length >= 4) // Ensure there's enough space for MM:SS format
            {
                // Update minutes display
                digitDisplays[0].sprite = numberSprites[minutes / 10];
                digitDisplays[1].sprite = numberSprites[minutes % 10];

                // Colon or separator handling can be added here if you have a specific display for that.

                // Update seconds display
                digitDisplays[2].sprite = numberSprites[seconds / 10]; 
                digitDisplays[3].sprite = numberSprites[seconds % 10];
            }
            else
            {
                Debug.LogError("Not enough digit displays assigned to show the time in MM:SS format.");
            }
        }

        // External controls for the timer, if needed
        public void StartTimer()
        {
            if (!timerIsRunning)
            {
                timerIsRunning = true;
                elapsedTime = 0; // Reset time if starting the timer anew
            }
        }

        public void StopTimer()
        {
            timerIsRunning = false;
        }
    }
}
