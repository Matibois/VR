using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject winCanva;
    [SerializeField] private GameObject looseCanva;
    [SerializeField] private GameObject menuCanva;

    [SerializeField] private Transform hand;
    [SerializeField] private Transform head;

    public float spawnDistance = 0.3f;

    [SerializeField] Vector3 _offset;
    public InputActionProperty MenuBUtton;

    private bool _winActive = false;
    private bool _looseActive = false;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        //timer.transform.position = hand.position ;
        //timer.transform.Translate(_offset, Space.Self);
        //timer.transform.LookAt(new Vector3 (head.position.x, head.position.y, 0));

        if (MenuBUtton.action.WasPressedThisFrame())
        {
            DiplayMenu();
        }

        
        menuCanva.transform.position = head.position + head.transform.forward*0.5f;
        menuCanva.transform.Translate(new Vector3(0,0,0.5f), Space.Self);

        menuCanva.transform.forward = head.transform.forward;
        //menuCanva.transform.LookAt(new Vector3(head.position.x, head.position.y, head.transform.position.z));
        
    }

    private void DiplayMenu()
    {
        menuCanva.SetActive(!menuCanva.activeSelf);
        //menuCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }

    public void DisplayWin()
    {
        winCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        winCanva.SetActive(true);
    }

    public void DisplayLoose()
    {
        looseCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        looseCanva.SetActive(true);
    }
}
