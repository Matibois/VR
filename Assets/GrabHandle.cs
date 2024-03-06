using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHandle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrabbed()
    {
        Debug.Log("Debut");
    }

    public void OnExitGrabbed()
    {
        Debug.Log("fin");
    }
}
