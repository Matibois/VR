using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject winCanva;
    [SerializeField] private GameObject looseCanva;
    [SerializeField] private GameObject menuCanva;


    [SerializeField] private GameObject displayValuePick;
    [SerializeField] private GameObject objectivesUI;
    [SerializeField] private TextMeshProUGUI text;
    Coroutine display;

    [SerializeField] private Transform hand;

    [SerializeField] private Transform head;

    public float spawnDistance = 0.3f;

    [SerializeField] Vector3 _offset;
    public InputActionProperty MenuBUtton;
    public InputActionProperty ObjectivesButton;

    private bool _winActive = false;
    private bool _looseActive = false;
    private bool _menuActive = false;


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
    private void Start()
    {
        _winActive = false;
        _looseActive = false;
        _menuActive = false;
    }

    // Update is called once per frame
    private void Update()
    {


        if (MenuBUtton.action.WasPressedThisFrame())
        {
            DiplayMenu();
        }

        if (ObjectivesButton.action.WasPressedThisFrame())
        {
            objectivesUI.SetActive(!objectivesUI.activeSelf);
        }

        displayValuePick.transform.position = head.position + head.transform.forward * 0.5f;
        displayValuePick.transform.Translate(new Vector3(0, 0, 0.5f), Space.Self);
        displayValuePick.transform.forward = head.transform.forward;

        if (_menuActive)
        {
            menuCanva.transform.position = head.position + head.transform.forward * 0.5f;
            menuCanva.transform.Translate(new Vector3(0, 0, 0.5f), Space.Self);
            menuCanva.transform.forward = head.transform.forward;
        }

        if(_winActive)
        {
            winCanva.transform.position = head.position + head.transform.forward * 0.5f;
            winCanva.transform.Translate(new Vector3(0, 0, 0.5f), Space.Self);
            winCanva.transform.forward = head.transform.forward;
        }

        if (_looseActive)
        {
            looseCanva.transform.position = head.position + head.transform.forward * 0.5f;
            looseCanva.transform.Translate(new Vector3(0, 0, 0.5f), Space.Self);
            looseCanva.transform.forward = head.transform.forward;
        }

    }

    public void HandlePickUI(int value)
    {
        if (display != null)
        {
            StopCoroutine(display);
        }

        display = StartCoroutine(DisplayPickValue(value));
    }

    IEnumerator DisplayPickValue(int value)
    {
        DisplayMenuPickValue(value);

        yield return new WaitForSeconds(2);

        StopDisplayPickValue();
    }

    public void DisplayMenuPickValue(int value)
    {
        text.text = "+ " + value.ToString() + "€";
        displayValuePick.gameObject.SetActive(true);
    }
    public void StopDisplayPickValue()
    {
        displayValuePick.gameObject.SetActive(false);
    }



    private void DiplayMenu()
    {
        _menuActive = !_menuActive;
        menuCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        menuCanva.SetActive(!menuCanva.activeSelf);
    }

    public void DisplayWin()
    {
        winCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        winCanva.SetActive(true);
        _winActive = true;
    }

    public void DisplayLoose()
    {
        looseCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        looseCanva.SetActive(true);
        _looseActive = true;
    }
}
