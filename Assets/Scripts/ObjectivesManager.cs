using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro _objectivesText;
    private List<Objective> _objectivesList = new List<Objective>();


    public void AddObjective(string description, ObjectiveType type, int amountToReach = 0)
    {
        _objectivesList.Add(new Objective(description, type, amountToReach));
    }

    public void EnterJewelry()
    {
        MarkObjectiveAsCompleted(0);
        GameManager.Instance.StartAlarmTimer();
    }

    public void DisarmAlarm()
    {
        MarkObjectiveAsCompleted(1);
        GameManager.Instance.DoorTrigger.SetActive(true);
    }

    public void StealJewels(int value)
    {
        _objectivesList[2].UpdateProgress(value);
        UpdateText();
    }

    public void StealSafe()
    {
        MarkObjectiveAsCompleted(3);
    }

    public void Flee()
    {
        MarkObjectiveAsCompleted(4);

        if(CheckIfEnoughValueIsStolen())
            GameManager.Instance.Win();
        else 
            GameManager.Instance.Lose();
    }

    public bool IsAlarmDisarmed()
    {
        return _objectivesList[1].IsCompleted;
    }

    public void InitObjectivesText()
    {
        UpdateText(); 
    }

    private void UpdateText()
    {
        string objectivesString = "";
        foreach (Objective objective in _objectivesList)
        {
            string desc = objective.Description;
            if(objective.Type == ObjectiveType.AmountToReach)
            {
                desc += " (" + objective.CurrentAmount + "/" + objective.AmountToReach + "€)";
            }

            if (objective.IsCompleted)
            {
                objectivesString += "<s>" + "- " + desc + "</s>" + "\n";
            }
            else
            {
                objectivesString += "- " + desc + "\n";
            }
        }
        // Update the text of the TextMeshPro object with the list of objectives
        _objectivesText.text = objectivesString;
    }

    private void MarkObjectiveAsCompleted(int index)
    {
        _objectivesList[index].MarkAsCompleted();
        UpdateText();
    }

    private bool CheckIfEnoughValueIsStolen()
    {
        return _objectivesList[2].IsCompleted;
    }
}

