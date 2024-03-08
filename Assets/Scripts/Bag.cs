using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private float totalMoney;

    public MeshRenderer ColliderMesh;

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
                ColliderMesh.enabled = true;
                pick.SetNearBag(true);
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
                ColliderMesh.enabled = false;
                pick.SetNearBag(false);
            }
        }
    }

    public void DeactivatePreview()
    {
        ColliderMesh.enabled = false;
    }
}
