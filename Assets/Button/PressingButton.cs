using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressingButton : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    AudioSource pressedAudio;

    void Start()
    {
        isPressed = false;
        pressedAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            isPressed = true;
            onPress.Invoke();
            pressedAudio.Play();
            presser = other.gameObject;
            button.transform.localPosition = new Vector3(0, 0.1f, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            isPressed = false;
            onRelease.Invoke();
            button.transform.localPosition = new Vector3(0, 0.2f, 0);
        }
    }

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent<Rigidbody>();
        sphere.transform.localPosition = new Vector3(1, 3, 2);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
