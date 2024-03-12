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
    private List<string> _objectivesList;
    [SerializeField] private TextMeshPro _objectivesText;

    public void Init()
    {
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
        _objectivesList.Add("S'enfuir avant la fin du temps imparti");
    }

    public void EnterJewelry()
    {
        UpdateObjectivesText(_objectivesList[0]);
    }

    public void DisarmAlarm()
    {
        UpdateObjectivesText(_objectivesList[1]);
    }
    
    public void StealJewels()
    {
        UpdateObjectivesText(_objectivesList[2]);
    }

    public void StealSafe()
    {
        UpdateObjectivesText(_objectivesList[3]);
    }

    public void Flee()
    {
        UpdateObjectivesText(_objectivesList[4]);
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

    public void UpdateObjectivesText(string completedObjective)
    {
        // Find the objective you want to achieve in the text and replace it with the crossed-out version
        _objectivesText.text = _objectivesText.text.Replace(completedObjective, "<s>" + completedObjective + "</s>");
    }
}

