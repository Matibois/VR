using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.XR.Content.Interaction;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Light _redLight;
    [SerializeField] private Light _blueLight;
    [SerializeField] private float _maxIntensity = 150;
    [SerializeField] private float _speed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        Light();
    }

    public void Light()
    {
        float sin = Mathf.Sin(Time.time * _speed);

        if(sin >= 0) 
        {
            _redLight.intensity = sin * _maxIntensity;
        }
        else
        {
            _blueLight.intensity = - sin * _maxIntensity;
        }

        //_blueLight.intensity.
    }
}
