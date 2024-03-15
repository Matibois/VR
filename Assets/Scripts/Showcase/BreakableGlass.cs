using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class BreakableGlass : MonoBehaviour
{
    [SerializeField] GameObject _glass;
    [SerializeField] GameObject _glassFractured;
    [SerializeField] private float _minForceToBreakGlass = 0.2f;
    [SerializeField] private AudioSource _breakGlassAudioSource;
    [SerializeField] private bool _causeAlarmWhenBroken = true;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // V�rifie si la collision s'est produite avec un autre collider
        if (collision.collider == null)
            return;

        if (!collision.gameObject.CompareTag("Player"))
            return;

        float mag = collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        //Debug.Log(mag);
        if (mag >= _minForceToBreakGlass)
        {
            // Obtient le point d'impact de la collision
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 pointOfImpact = contactPoint.point;
            BreakGlass(pointOfImpact);
            _breakGlassAudioSource.pitch = Random.Range(0.8f, 1.2f);
            _breakGlassAudioSource.Play();
        }
    }

    public void BreakGlass(Vector3 breakPos)
    {
        _glass.SetActive(false);
        _glassFractured.SetActive(true);
        _glassFractured.transform.parent = null;

        Transform transform = _glassFractured.transform;

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<Rigidbody>().AddExplosionForce(100, breakPos, 10);
        }

        if (_causeAlarmWhenBroken)
            GameManager.Instance.GlassBroken();
    }
}
