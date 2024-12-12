using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PickUp : MonoBehaviour
{
    [SerializeField] private InputActionReference rotateCube;
    [SerializeField] private InputActionReference pickUpCube;
    [SerializeField] public float pickUpRange = 1f;
    [SerializeField] public float pickUpForce = 150.0f;
    [SerializeField] private Transform holdArea;
    private GameObject pickUpCubeObj;
    private GameObject heldCube = null;
    private Rigidbody heldCubeRb = null;
    public GameObject player;
    // public Transform holdPos;
    public float rotationAngle = 5f;
    private bool canHold = false;
    private bool isHeld = false;
    public Transform rightHand;
     [SerializeField]
    private LayerMask pickUpMask;
    void Start()
    {
            

    }
    void Update()
    {
        float pickUpCubeValue = pickUpCube.action.ReadValue<float>();
        if(pickUpCubeValue > 0.5f) 
        {
            canHold = true;
            RaycastHit hit;
            if (Physics.Raycast(rightHand.position, rightHand.forward, out hit, pickUpRange, pickUpMask))
            {
                GameObject target = hit.transform.gameObject;
                PickUpCube(target);  
            }
        }
        else {
            canHold = false;
            if (isHeld) DropObject();
        }
    }
    void PickUpCube(GameObject pickUpCubeObj)
    {
        if (canHold == true) {
            heldCubeRb = pickUpCubeObj.GetComponent<Rigidbody>();
            heldCube = pickUpCubeObj;
            isHeld = true;
            heldCubeRb.useGravity = false;
            heldCubeRb.drag = 10;
            heldCube = pickUpCubeObj;
            heldCubeRb.constraints = RigidbodyConstraints.FreezeRotation;
            heldCubeRb.transform.parent = holdArea;
            rotateCube.action.performed += RotateObject;
            if (heldCube != null)
            {
                moveObject();
            }
        }
    }
    void DropObject()
    {
        isHeld = false;
        heldCubeRb.useGravity = true;
        heldCubeRb.drag = 1;
        heldCubeRb.constraints = RigidbodyConstraints.None;
        //heldCube.layer = 0;
        heldCubeRb.isKinematic = false;
        heldCube.transform.parent = null; 
        heldCube = null; 
    }
    void RotateObject(InputAction.CallbackContext _)
    {
        if (isHeld) {
            heldCube.transform.Rotate(0f, 0f, rotationAngle);
        }
        
}
void moveObject()
{
    if (Vector3.Distance(heldCube.transform.position, holdArea.position) > 0.1f)
    {
        Vector3 moveDirection = holdArea.position - heldCube.transform.position;

      
        heldCubeRb.AddForce(moveDirection * pickUpForce); 
    }
}
}

