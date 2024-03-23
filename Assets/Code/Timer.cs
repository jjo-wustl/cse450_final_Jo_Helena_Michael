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
        public Image[] bestTimeDisplay;
         
        private float elapsedTime = 0f; // Tracks the elapsed time
        public bool timerIsRunning = false;

        int bestTime = 10000;
        void Start()
        {
            Debug.Log(PlayerPrefs.HasKey("BestTime"));
            if (PlayerPrefs.HasKey("BestTime"))
            {
                //if (PlayerPrefs.GetInt("BestTime") == 0)
                //{
                //    PlayerPrefs.SetInt("BestTime", bestTime);
                //}
                bestTime = PlayerPrefs.GetInt("BestTime");
                if (bestTime < 10000)
                {
                    int minutes = bestTime / 60;
                    int seconds = bestTime % 60;

                    bestTimeDisplay[0].sprite = numberSprites[minutes / 10];
                    bestTimeDisplay[1].sprite = numberSprites[minutes % 10];

                    bestTimeDisplay[2].sprite = numberSprites[seconds / 10];
                    bestTimeDisplay[3].sprite = numberSprites[seconds % 10];
                }
            }
            else
            {
                PlayerPrefs.SetInt("BestTime", 10000);
                PlayerPrefs.Save(); //added here
            }
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
                
                // Update seconds display
                digitDisplays[2].sprite = numberSprites[seconds / 10]; 
                digitDisplays[3].sprite = numberSprites[seconds % 10];
            }
            else
            {
                Debug.LogError("Not enough digit displays assigned to show the time in MM:SS format.");
            }
        }

        public void SaveBestTime()
        {
            print("elapsed: " + elapsedTime);
            print("best: " + bestTime);
            if (elapsedTime < bestTime)
            {
                bestTime = Mathf.FloorToInt(elapsedTime);
                PlayerPrefs.SetInt("BestTime", bestTime);
                PlayerPrefs.Save();
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
