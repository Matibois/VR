using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private Transform head;
    public float spawnDistance = 0.3f;

    [SerializeField] Vector3 _offset;

    public float tempy; 
    public float tempz; 
    
    [SerializeField] private GameObject canvas;
    public InputActionProperty DisplayUI;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        canvas.transform.position = hand.position + hand.transform.forward;

        canvas.transform.LookAt(new Vector3 (head.position.x, head.position.y, head.transform.position.z));

        canvas.transform.Translate(_offset, Space.Self);


        if (DisplayUI.action.WasPressedThisFrame())
        {
            canvas.SetActive(!canvas.activeSelf);
        }
        //canvas.transform.position = head.position + new Vector3(head.forward.x, tempy, head.forward.z+tempz).normalized * spawnDistance;
    }
}
