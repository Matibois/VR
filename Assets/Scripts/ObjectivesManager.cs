using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Burst.Intrinsics.X86.Avx;

/* ObjectivesManager :
- possède tout les objectifs
- declenche des events lorqu’on set un bool (qui resulte d’une action du joueur)
- dans update du gamemanger verifier si les events sont done ou pas
*/
public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro _objectivesText;
    private List<Objective> _objectivesList = new List<Objective>();

    private void Start()
    {
        Invoke("EnterJewelry", 1);
        Invoke("Test", 2);
        Invoke("Test", 3);
    }

    private void Test()
    {
        StealJewels(100);
    }

    public void AddObjective(string description, ObjectiveType type, int amountToReach = 0)
    {
        _objectivesList.Add(new Objective(description, type, amountToReach));
    }

    public void EnterJewelry()
    {
        MarkObjectiveAsCompleted(0);
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
    }

    public void InitObjectivesText()
    {
        UpdateText(); 
    }

    public void UpdateText()
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
            } else
            {
                objectivesString += "- " + desc + "\n";
            }
        }
        // Update the text of the TextMeshPro object with the list of objectives
        _objectivesText.text = objectivesString;
    }

    public void MarkObjectiveAsCompleted(int index)
    {
        _objectivesList[index].MarkAsCompleted();
        UpdateText();
    }
}

