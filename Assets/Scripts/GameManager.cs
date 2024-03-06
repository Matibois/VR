using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool hasEnteredJewelry = false;
    private bool hasDisarmedAlarm = false;
    private bool hasFled = false;

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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterJewelry()
    {
        hasEnteredJewelry = true;
    }

    public void DisarmAlarm() 
    { 
        hasDisarmedAlarm = true; 
    }

    public void Flee() 
    { 
        hasFled = true; 
    }
}
