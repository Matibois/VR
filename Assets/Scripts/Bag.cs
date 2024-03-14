using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bag : MonoBehaviour
{
    private float totalMoney;

    private MeshRenderer ColliderMesh;
    private int nbObjCollide = 0;

    void Awake()
    {
        ColliderMesh = GetComponent<MeshRenderer>();
        ColliderMesh.enabled = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            Pickable pick;
            if (other.gameObject.TryGetComponent<Pickable>(out pick))
            {
                if (pick.GetIsPicked())
                {
                    nbObjCollide++;
                    ColliderMesh.enabled = true;
                    pick.SetNearBag(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            Pickable pick;
            if (other.gameObject.TryGetComponent<Pickable>(out pick))
            {
                nbObjCollide--;
                if (nbObjCollide == 0)
                    ColliderMesh.enabled = false;
                pick.SetNearBag(false);
            }
        }
    }

    public void PickObject(SelectExitEventArgs args)
    {
        nbObjCollide--;
        if (nbObjCollide == 0)
            ColliderMesh.enabled = false;

    }
}
