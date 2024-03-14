using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Jewerly : Pickable
{
    public int value;
    Coroutine display;

    // Start is called before the first frame update
    new void Start()
    {
        Debug.Log("Child");
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TestPutInBag(SelectExitEventArgs args)
    {
        if (nearBag)
        {
            Debug.Log("OUI");
            if (display != null)
                StopCoroutine(display);

            GameManager.Instance.JewelStolen(value);

            display = StartCoroutine(DisplayPickValue());
            transform.gameObject.SetActive(false);
        }
    }

    IEnumerator DisplayPickValue()
    {
        Debug.Log("Display");
        UIManager.Instance.DisplayMenuPickValue(value);
        yield return new WaitForSeconds(1);
        UIManager.Instance.StopDisplayPickValue();
        Debug.Log("No");

    }
}
