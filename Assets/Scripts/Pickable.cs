using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    private bool isPicked;
    private bool nearBag;

    private void Start()
    {
        isPicked = false;
        nearBag = false;
    }

    public void SetIsPicked(bool _isPicked)
    {
        isPicked = _isPicked;
    }

    public bool GetIsPicked()
    {
        return isPicked;
    }

    public void SetNearBag(bool _nearBag)
    {
        nearBag = _nearBag;
    }

    public void TestPutInBag()
    {
        if(nearBag)
        {
            Debug.Log("InBag");
            transform.gameObject.SetActive(false);
        }
    }
}
