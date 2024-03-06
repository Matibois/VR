using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    

    [SerializeField] private Timer _timer;

    private bool _hasEnteredJewelry = false;
    private bool _hasDisarmedAlarm = false;
    private bool _hasFled = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterJewelry()
    {
        _hasEnteredJewelry = true;
    }

    public void DisarmAlarm() 
    { 
        _hasDisarmedAlarm = true; 
    }

    public void Flee() 
    { 
        _hasFled = true; 
    }
}
