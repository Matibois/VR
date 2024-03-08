using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BreakableGlass : MonoBehaviour
{
    [SerializeField] GameObject _glass;
    [SerializeField] GameObject _glassFractured;

    // Start is called before the first frame update
    void Start()
    {
        // Test
        //BreakGlass(new Vector3(4, 0.7f, 1.3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si la collision s'est produite avec un autre collider
        if (collision.collider != null)
        {
            // Obtient le point d'impact de la collision
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 pointOfImpact = contactPoint.point;
            BreakGlass(pointOfImpact);
        }
    }

    public void BreakGlass(Vector3 breakPos)
    {
        _glass.SetActive(false);
        _glassFractured.SetActive(true);

        Transform transform = _glassFractured.transform;

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<Rigidbody>().AddExplosionForce(100, breakPos, 10);
        }
    }
}
