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
        
        //update the PlayerPrefs key for each level
        private string GetBestTimeKey()
        {
            string levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            return levelName + "_BestTime";
        }
        void Start()
        {
            LoadBestTime();
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
            int time = Mathf.FloorToInt(elapsedTime); //time won't reach a minute so there's no need to calculate minutes

            if (digitDisplays.Length >= 2)
            {
                // Update time display
                digitDisplays[0].sprite = numberSprites[time / 10];
                digitDisplays[1].sprite = numberSprites[time % 10];
            }
            else
            {
                Debug.LogError("Not enough digit displays assigned to show the time in MM:SS format.");
            }
        }
        
        private void LoadBestTime()
        {
            string bestTimeKey = GetBestTimeKey();
            if (PlayerPrefs.HasKey(bestTimeKey))
            {
                bestTime = PlayerPrefs.GetInt(bestTimeKey);
                //print("best time on load: " + bestTime);
                if (bestTime < 1000 && bestTime > 0)
                {
                    bestTimeDisplay[0].sprite = numberSprites[bestTime / 10];
                    bestTimeDisplay[1].sprite = numberSprites[bestTime % 10];
                }else if (bestTime <= 0)
                {
                    PlayerPrefs.SetInt(bestTimeKey, 10000);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                PlayerPrefs.SetInt(bestTimeKey, 10000);
                PlayerPrefs.Save();
            }
        }

        public void SaveBestTime()
        {
            string bestTimeKey = GetBestTimeKey();
            if (elapsedTime < bestTime)
            {
                bestTime = Mathf.FloorToInt(elapsedTime);
                PlayerPrefs.SetInt(bestTimeKey, bestTime);
                PlayerPrefs.Save();
            }
        }

        public void resetBestTime()
        {
            string bestTimeKey = GetBestTimeKey();
            PlayerPrefs.SetInt(bestTimeKey, 10000);
            PlayerPrefs.Save();
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
