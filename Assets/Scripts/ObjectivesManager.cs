using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

/* ObjectivesManager :
- possède tout les objectifs
- declenche des events lorqu’on set un bool (qui resulte d’une action du joueur)
- dans update du gamemanger verifier si les events sont done ou pas
*/
public class ObjectivesManager : MonoBehaviour
{
    public UnityEvent<string> _onObjectiveCompleted;
    private List<string> _objectivesList;
    private TextMeshPro _objectivesText;

    // Player Objectives
    private bool _hasEnteredJewelry = false;
    private bool _hasDisarmedAlarm = false;
    private bool _hasFled = false;

    public void Init()
    {
        _onObjectiveCompleted = new UnityEvent<string>();
        _objectivesList = new List<string>();
        AddObjectives();
        InitObjectivesText();
    }

    private void AddObjectives()
    {
        _objectivesList.Add("Entrer dans la bojouterie");
        _objectivesList.Add("Désactiver l'alarme");
        _objectivesList.Add("Voler les bijoux de la liste");
        _objectivesList.Add("Voler le contenu du coffre-fort");
        _objectivesList.Add("S'enfuir avant la fin du temps impartie");
    }

    public void EnterJewelry()
    {
        _onObjectiveCompleted.Invoke(_objectivesList[0]);
    }

    public void DisarmAlarm()
    {
        _onObjectiveCompleted.Invoke(_objectivesList[1]);
    }
    
    public void StealJewels()
    {
        _onObjectiveCompleted.Invoke(_objectivesList[2]);
    }

    public void StealSafe()
    {
        _onObjectiveCompleted.Invoke(_objectivesList[3]);
    }

    public void Flee()
    {
        _onObjectiveCompleted.Invoke(_objectivesList[4]);
    }

    private void InitObjectivesText()
    {
        // Construct a string containing all objectives
        string objectivesString = "";
        foreach (string objective in _objectivesList)
        {
            // Add each objective on a new line
            objectivesString += "- " + objective + "\n";
        }

        // Update the text of the TextMeshPro object with the list of objectives
        _objectivesText.text = objectivesString;
    }

    private void UpdateObjectivesText(string completedObjective)
    {
        // Find the objective you want to achieve in the text and replace it with the crossed-out version
        _objectivesText.text = _objectivesText.text.Replace(completedObjective, "<s>" + completedObjective + "</s>");
    }
}

