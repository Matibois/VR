using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlassCollision : MonoBehaviour
{

    public UnityEvent GlassCollide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si la collision s'est produite avec un autre collider
        if (collision.collider != null)
        {
            // Obtient le point d'impact de la collision
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 pointOfImpact = contactPoint.point;
            //BreakGlass(pointOfImpact);
        }
    }
}
