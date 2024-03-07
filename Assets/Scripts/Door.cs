using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openingAngle = 90f; // Angle d'ouverture de la porte
    public float openingSpeed = 2f; // Vitesse d'ouverture de la porte

    private Quaternion initialRotation; // Rotation initiale de la porte
    private Quaternion targetRotation; // Rotation cible de la porte
    private bool isOpening = false; // Indique si la porte est en train de s'ouvrir

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, openingAngle, 0) * initialRotation;
        BreakWindow();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            // Interpole progressivement la rotation de la porte vers la rotation cible
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openingSpeed);
            if (transform.rotation == targetRotation)
                isOpening = false;
        }
    }

    public void BreakWindow()
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Material[] newMats = new Material[meshRenderer.materials.Length -1];

        int indexToRemove = 1;

        for (int i = 0, j = 0; i < meshRenderer.materials.Length; i++)
        {
            if (i != indexToRemove)
            {
                newMats[j++] = meshRenderer.materials[i];
            }
        }

        meshRenderer.materials = newMats;
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
}
