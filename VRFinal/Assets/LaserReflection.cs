using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReflection : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxLaserLength = 200f;
    public Transform secretDoor; 
    public float moveDistance = 30f;

void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }
    void Update()
    {
        ShootLaserFromPosition(transform.position, transform.forward);
    }

        void ShootLaserFromPosition(Vector3 start, Vector3 direction)
    {
        Ray ray = new Ray(start, direction);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxLaserLength))
        {
            lineRenderer.positionCount = 2; // Just the original laser
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("mirror"))
            {
                Vector3 reflectedDirection = Vector3.Reflect(direction, hit.normal);
                RaycastHit hitReflection;

                if (Physics.Raycast(hit.point + reflectedDirection * 0.01f, reflectedDirection, out hitReflection, maxLaserLength))
                {
                    lineRenderer.positionCount = 3; // Extend for the reflection
                    lineRenderer.SetPosition(2, hitReflection.point);
                }
                else
                {
                    lineRenderer.positionCount = 3;
                    lineRenderer.SetPosition(2, hit.point + reflectedDirection * maxLaserLength);
                }
                if (hitReflection.collider.CompareTag("target"))
                {
                    Debug.Log("hit target");
                    // Move the secret door if it exists
                    if (secretDoor != null && secretDoor.gameObject.layer == LayerMask.NameToLayer("secretDoor"))
                    {
                        secretDoor.Translate(Vector3.forward * moveDistance);
                    }
                }
            }
        }
        else
        {
            lineRenderer.positionCount = 1; // No hit, just draw in one direction
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, start + direction * maxLaserLength);
        }
    }
}