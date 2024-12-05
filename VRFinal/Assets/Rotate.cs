using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private InputActionReference rotateMirrorClockWise;
    [SerializeField]
    private InputActionReference rotateMirrorCounterClockWise;

    [SerializeField]
    private LayerMask mirrorMask;

    public float constantRotationSpeed = 30f; // Rotation speed in degrees per second

    private float currentRotationDirection = 0f; // -1 for counterclockwise, 1 for clockwise, 0 for no rotation


    private void OnEnable()
    {
        rotateMirrorClockWise.action.performed += _ => currentRotationDirection = 1f;
        rotateMirrorClockWise.action.canceled += _ => currentRotationDirection = 0f;
        rotateMirrorCounterClockWise.action.performed += _ => currentRotationDirection = -1f;
        rotateMirrorCounterClockWise.action.canceled += _ => currentRotationDirection = 0f;
    }

    private void OnDisable()
    {
        rotateMirrorClockWise.action.Disable();
        rotateMirrorCounterClockWise.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRotationDirection != 0f)
        {
            RotateMirror(currentRotationDirection * constantRotationSpeed * Time.deltaTime);
        }
    }

    void RotateMirror(float rotationAmount)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mirrorMask))
        {
            hit.transform.parent.Rotate(0f, rotationAmount, 0f);
        }
    }
}
