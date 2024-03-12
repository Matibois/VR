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
    [SerializeField] private TextMeshPro textCode;
    [SerializeField] private XRSimpleInteractable[] Bouton;
    private string codeString;
    private string codeToFind = "3141";
    private int buttonID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestCode()
    {
        if (codeString == codeToFind)
        {
            GetComponent<Rigidbody>().isKinematic = true;

        }

;    }

    public void ActiveButton(ActivateEventArgs activateEvent)
    {
        XRSimpleInteractable Button = activateEvent.interactable.GetComponent<XRSimpleInteractable>();

        for (int i = 0; i < Bouton.Length; i++)
        {
            if (Button == Bouton[i])
            {
                ImplementCode(i);
            }
        }
    }

    private void ImplementCode(int buttonID) // button id == le numéro sur le bouton de l'alarme, 10 == bouton reset
    {
        if (buttonID == 10)
        {
            codeString = "";
        }
        else
        {
            codeString += buttonID;
            if (codeString.Length ==4) TestCode();
            textCode.text = codeString;
        }
    }

}
