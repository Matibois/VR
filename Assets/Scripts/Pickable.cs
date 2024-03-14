using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Pickable : MonoBehaviour
{
    protected bool isPicked;
    protected bool nearBag;

    protected Bag bag;
    protected XRGrabInteractable inter;

    protected Rigidbody rb;
    public bool PhysicsEnable;

    protected void Start()
    {
        isPicked = false;
        nearBag = false;

        inter = GetComponent<XRGrabInteractable>();
        inter.movementType = XRBaseInteractable.MovementType.VelocityTracking;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = PhysicsEnable;

        // Put convex at true for mesh colliders
        MeshCollider temp;
        TryGetComponent<MeshCollider>(out temp);
        if (temp != null)
            temp.convex = true;


        bag = GameObject.FindGameObjectWithTag("BagCollider").GetComponent<Bag>();


        inter.firstSelectEntered.AddListener(SetIsPicked);

        inter.lastSelectExited.AddListener(SetIsNotPicked);
        //inter.lastSelectExited.AddListener(bag.PickObject);
    }

    public void SetIsPicked(SelectEnterEventArgs args)
    {
        isPicked = true;
        rb.isKinematic = false;
    }

    public void SetIsNotPicked(SelectExitEventArgs args)
    {
        isPicked = false;
        rb.isKinematic = false;
    }

    public bool GetIsPicked()
    {
        return isPicked;
    }

    public void SetNearBag(bool _nearBag)
    {
        nearBag = _nearBag;
    }

/*    public virtual void TestPutInBag(SelectExitEventArgs args)
    {
        if(nearBag)
        {
            transform.gameObject.SetActive(false);
        }
    }*/
}
