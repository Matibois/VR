using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class KeyDetection : MonoBehaviour
{
    [SerializeField] private GameObject _keyAttach;
    [SerializeField] private float _openingAngle = 90f; // Angle d'ouverture de la porte
    [SerializeField] private float _rotationSpeed = 3f; // Vitesse d'ouverture de la porte
    [SerializeField] private GameObject[] _doorsToOpen;

    bool _isUnlocking = false;
    bool _unlocked = false;
    private Quaternion _initialRotation; 
    private Quaternion _targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        _initialRotation = transform.rotation;
        _targetRotation = Quaternion.Euler(0, 0, _openingAngle) * _initialRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isUnlocking)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, Time.deltaTime * _rotationSpeed);
            if (transform.rotation == _targetRotation)
            {
                _isUnlocking = false;
                _unlocked = true;
            }
        }
        
        if(_unlocked)
        {
            _doorsToOpen[0].GetComponent<Door>().OpenDoor();
            _doorsToOpen[1].GetComponent<Door>().Invoke("OpenDoor", 1);
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        if (!other.gameObject.CompareTag("Key"))
            return;

        Destroy(other.gameObject);
        Unlock();
    }

    private void Unlock()
    {
        _keyAttach.SetActive(true);
        _isUnlocking = true;
        GameManager.Instance.EnterJewelry();
    }
}
