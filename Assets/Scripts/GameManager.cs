using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private Timer _timer;
    [SerializeField] private ObjectivesManager _objectivesManager;
    [SerializeField] private Objective _objective;
    [SerializeField] private GameObject _doorTrigger;
    private int _amountToSteal;

    public ObjectivesManager ObjectivesManager => _objectivesManager;
    public GameObject DoorTrigger => _doorTrigger;

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
        _amountToSteal = 3000;
        SetObjectives();
        _timer.StartTimer();
        _doorTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetObjectives()
    {
        _objectivesManager.AddObjective("Entrer dans la bijouterie", ObjectiveType.Simple);
        _objectivesManager.AddObjective("Désactiver l'alarme", ObjectiveType.Simple);
        _objectivesManager.AddObjective($"Remplir le sac de bijoux", ObjectiveType.AmountToReach, _amountToSteal);
        _objectivesManager.AddObjective("Voler le contenu du coffre-fort", ObjectiveType.Simple);
        _objectivesManager.AddObjective("S'enfuir avant la fin du temps imparti", ObjectiveType.Simple);
        _objectivesManager.InitObjectivesText();
    }

    public void JewelStolen(int value)
    {
        _objectivesManager.StealJewels(value);
    }

    public void Win()
    {
        Debug.Log("Win");
    }

    public void Lose()
    {
        Debug.Log("Lose");
    }
}
