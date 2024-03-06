using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float _initialTime = 180.0f;
    private float _timeRemaining;
    private Text _timeText; // UI

    private bool _timerIsRunning = false;

    public void StartTimer()
    {
        _timeRemaining = _initialTime;
        DisplayTime(_timeRemaining);
        _timerIsRunning = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                _timeRemaining = 0;
                // Game Over !
                _timerIsRunning = false;
            }
        }
        DisplayTime(_timeRemaining);
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // To display the last second

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
