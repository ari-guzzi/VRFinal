using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReflection : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float maxLaserLength = 200f;
    public float moveDistance = 30f;

void Start()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

 
    void Update()
    {
        List<Vector3> points = new List<Vector3>();
        CastRay(transform.position, transform.forward, points);
        UpdateLineRenderer(points);
    }

    void CastRay(Vector3 start, Vector3 direction, List<Vector3> points)
    {
        points.Add(start);
        Ray ray = new Ray(start, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxLaserLength))
        {
            points.Add(hit.point);
            if (hit.collider.CompareTag("target"))
            {
                MoveParent(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("mirror"))
            {
                Vector3 reflectedDirection = Vector3.Reflect(direction, hit.normal);
                if (points.Count < 50) // To prevent infinite loops, so only 50 reflfections are allowed
                {
                    CastRay(hit.point + reflectedDirection * 0.01f, reflectedDirection, points);
                }
            }
        }
        else
        {
            points.Add(start + direction * maxLaserLength);
        }
    }

    void UpdateLineRenderer(List<Vector3> points)
    {
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    void MoveParent(GameObject target)
    {
        Transform parent = target.transform.parent;
        if (parent != null)
        {
            parent.Translate(Vector3.forward * moveDistance);
        }
        else
        {
            Debug.LogWarning("Target has no parent object to move.");
        }
    }
}