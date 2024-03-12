using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private Timer _timer;
    [SerializeField] private ObjectivesManager _objectivesManager;
    [SerializeField] private GameObject _doorTrigger;

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
        _timer.StartTimer();
        _objectivesManager.Init();
        _doorTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Loose ()
    {

    }
}
