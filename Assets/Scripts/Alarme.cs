using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using UnityEngine.XR.Interaction.Toolkit;

public class Alarme : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textCode;
    [SerializeField] private XRSimpleInteractable[] _bouton;
    private string _codeString;
    private string _codeToFind = "3141";

    [SerializeField] public Timer _timer;
    private bool wait = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        if (wait)
        {

        }
    }

    public void StartTimer()
    {
        _timer.StartTimer();
    }

    public void TestCode()
    {
        if (_codeString == _codeToFind)
        {
            _textCode.color = Color.green;
            StartCoroutine(WaitTestCode(true));
        }
        else
        {
            _textCode.color = Color.red;
            StartCoroutine(WaitTestCode(false));
        }
        _codeString = "";
    }

    public void ActiveButton(ActivateEventArgs activateEvent)
    {
        XRSimpleInteractable Button = activateEvent.interactable.GetComponent<XRSimpleInteractable>();

        for (int i = 0; i < _bouton.Length; i++)
        {
            if (Button == _bouton[i])
            {
                ImplementCode(i);
            }
        }
    }

    private void ImplementCode(int buttonID) // button id == le num�ro sur le _bouton de l'alarme, 10 == _bouton reset
    {
        if (buttonID == 10)
        {
            _codeString = "";
            _textCode.SetText(_codeString);
        }
        else
        {
            _codeString += buttonID;
            _textCode.SetText(_codeString);
            if (_codeString.Length ==4) TestCode();
        }
        

    }

    IEnumerator WaitTestCode(bool result)
    {
        yield return new WaitForSeconds(1);
        if (result)DesactivateAlarm();
        else ResetAlarm();
    }

    private void DesactivateAlarm()
    {
        _timer.StopTimer();
        GetComponent<Rigidbody>().isKinematic = true;
        GameManager.Instance.ObjectivesManager.DisarmAlarm();
    }

    private void ResetAlarm()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        _codeString = "";
        _textCode.color = Color.white;
        _textCode.SetText(_codeString);
    }

}
