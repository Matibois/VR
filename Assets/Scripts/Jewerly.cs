using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jewerly : Pickable
{
    public int value;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
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
            GameManager.Instance.JewelStolen(value);
        }
    }
}
