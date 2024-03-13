using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject WinCanva;
    [SerializeField] private GameObject LooseCanva;
    [SerializeField] private GameObject MenuCanva;

    [SerializeField] private Transform hand;
    [SerializeField] private Transform head;

    public float spawnDistance = 0.3f;

    [SerializeField] Vector3 _offset;
    public InputActionProperty MenuBUtton;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        timer.transform.position = hand.position + hand.transform.forward;
        timer.transform.LookAt(new Vector3 (head.position.x, head.position.y, head.transform.position.z));
        timer.transform.Translate(_offset, Space.Self);

        if (MenuBUtton.action.WasPressedThisFrame()) DiplayMenu();
        
    }

    private void DiplayMenu()
    {
        MenuCanva.SetActive(!timer.activeSelf);
        MenuCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }

    public void DisplayWin()
    {
        WinCanva.SetActive(true);
        WinCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }

    public void DisplayLoose()
    {
        LooseCanva.SetActive(true);
        LooseCanva.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
    }
}
