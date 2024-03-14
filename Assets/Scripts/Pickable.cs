using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Pickable : MonoBehaviour
{
    protected bool isPicked;
    protected bool nearBag;

    private Bag bag;

    protected void Start()
    {
        isPicked = false;
        nearBag = false;

        XRGrabInteractable inter = GetComponent<XRGrabInteractable>();
        bag = GameObject.FindGameObjectWithTag("BagCollider").GetComponent<Bag>();


        inter.firstSelectEntered.AddListener(SetIsPicked);

        inter.lastSelectExited.AddListener(SetIsNotPicked);
        inter.lastSelectExited.AddListener(TestPutInBag);
        inter.lastSelectExited.AddListener(bag.PickObject);
    }

    public void SetIsPicked(SelectEnterEventArgs args)
    {
        isPicked = true;
    }

    public void SetIsNotPicked(SelectExitEventArgs args)
    {
        isPicked = false;
    }

    public bool GetIsPicked()
    {
        return isPicked;
    }

    public void SetNearBag(bool _nearBag)
    {
        nearBag = _nearBag;
    }

    public virtual void TestPutInBag(SelectExitEventArgs args)
    {
        if(nearBag)
        {
            Debug.Log("parent");
            transform.gameObject.SetActive(false);
        }
    }
}
