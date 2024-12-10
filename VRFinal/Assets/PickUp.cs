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
    public GameObject pickUpCubeObj;
    private GameObject heldCube = null;
    private Rigidbody heldCubeRb = null;
    public GameObject player;
    public Transform holdPos;
    public float rotationAngle = 5f;
    private bool canHold = false;
    private bool isHeld = false;
    public Transform rightHand;
    void Start()
    {
            heldCubeRb = pickUpCubeObj.GetComponent<Rigidbody>();
            heldCube = pickUpCubeObj;

    }
    void Update()
    {
        float pickUpCubeValue = pickUpCube.action.ReadValue<float>();
        if(pickUpCubeValue > 0.5f) 
        {
            canHold = true;
            RaycastHit hit;
            if (Physics.Raycast(rightHand.position, rightHand.forward, out hit, pickUpRange))
            {
               GameObject target = hit.transform.gameObject;
                Debug.Log("Hit: " + target.name);

                    PickUpCube(target);  
            }
    }
    else {
                canHold = false;
                DropObject();
            }
    }
    void PickUpCube(GameObject pickCube)
    {
        if (canHold == true) {
            isHeld = true;
            heldCubeRb.useGravity = false;
            heldCubeRb.drag = 10;
            heldCube = pickUpCubeObj;
            //freeze the rotation of the cube
            heldCubeRb.constraints = RigidbodyConstraints.FreezeRotation;
            //heldCubeRb.constraints = RigidbodyConstaints.FreezeRotation;
            heldCubeRb.transform.parent = holdArea;
            //make sure object doesnt collide with player 
            //Physics.IgnoreCollision(heldCube.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            rotateCube.action.performed += RotateObject;
        if (heldCube != null)
            {
                moveObject();
            }
        }
    }
    void DropObject()
    {
        heldCube = pickUpCubeObj;
        heldCubeRb.useGravity = true;
        heldCubeRb.drag = 1;
        heldCubeRb.constraints = RigidbodyConstraints.None;
        //re-enable collision with player
//        Physics.IgnoreCollision(heldCube.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldCube.layer = 0; //object assigned back to default layer
        heldCubeRb.isKinematic = false;
        heldCube.transform.parent = null; //unparent object
        heldCube = null; //undefine game object
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

