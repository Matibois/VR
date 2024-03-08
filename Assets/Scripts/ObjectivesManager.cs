using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectivesManager : MonoBehaviour
{
    public UnityEvent onObjectiveCompleted = new UnityEvent();

    // Player Objectives
    private bool _hasEnteredJewelry = false;
    private bool _hasDisarmedAlarm = false;
    private bool _hasFled = false;
    private string _currentObjective = "Entrer dans la bijouterie";

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterJewelry()
    {
        _hasEnteredJewelry = true;
        _currentObjective = "Désarmer l'alarme";
        onObjectiveCompleted.Invoke();
    }


    public void DisarmAlarm()
    {
        _hasDisarmedAlarm = true;
        _currentObjective = "Vol des bijoux";
        onObjectiveCompleted.Invoke();
    }


    public void Flee()
    {
        _hasFled = true;
        _currentObjective = "Objectif atteint";
        onObjectiveCompleted.Invoke();
    }


    public string GetCurrentObjective()
    {
        return _currentObjective;
    }
}
