using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeTextCanva; // UI
    [SerializeField] private TextMeshPro _timeText; // UI
    public float _initialTime = 180.0f;
    private float _timeRemaining;

    public bool _timerIsRunning = false;
    public bool _finish = false;

    public void StartTimer()
    {
        _timeRemaining = _initialTime;
        _timerIsRunning = true;
    }

    public void StopTimer()
    {
        _timerIsRunning = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                _timeRemaining = 0;
                // Game Over !
                _timerIsRunning = false;
                GameManager.Instance.Lose();
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // To display the last second

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (_timeText != null)_timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        else _timeTextCanva.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
