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
    [SerializeField] private TextMeshPro InputFieldCode;
    [SerializeField] private XRSimpleInteractable Bouton;
    private string codeString;
    private int code;

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
        codeString = InputFieldCode.GetComponent<InputField>().text;
        code = Int32.Parse(codeString)
;    }

}
