using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private float _openingAngle = 90f; // Angle d'ouverture de la porte
    [SerializeField] private float _openingSpeed = 1f; // Vitesse d'ouverture de la porte
    [SerializeField] private GameObject _glass; // Vitesse d'ouverture de la porte

    private Quaternion _initialRotation; // Rotation initiale de la porte
    private Quaternion _targetRotation; // Rotation cible de la porte
    private bool _isOpening = false; // Indique si la porte est en train de s'ouvrir
    private bool _glassBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        _initialRotation = transform.rotation;
        _targetRotation = Quaternion.Euler(0, _openingAngle, 0) * _initialRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOpening)
        {
            // Interpole progressivement la rotation de la porte vers la rotation cible
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, Time.deltaTime * _openingSpeed);
            if (transform.rotation == _targetRotation)
            {
                _isOpening = false;
                enabled = false;
            }
        } else
        {
            if(IsGlassBroken() && _glassBroken == false && _isOpening == false)
            {
                _glassBroken = true;
                GameManager.Instance.Lose();
            }
        }
    }

    public void OpenDoor()
    {
        _isOpening = true;
    }

    private bool IsGlassBroken()
    {
        return !_glass.activeInHierarchy;
    }
}
