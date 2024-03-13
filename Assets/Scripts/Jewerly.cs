using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jewerly : Pickable
{
    public float value;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public new void TestPutInBag(SelectExitEventArgs args)
    {
        if (nearBag)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
