using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Rotate : MonoBehaviour
{
    [SerializeField]
    private InputActionReference rotateMirrorPress;

    [SerializeField]
    private LayerMask mirrorMask;
    public float rotationAngle = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rotateMirrorPress.action.performed += Turn;
    }

    // Update is called once per frame
    void Update()
    {  

    }
    void Turn(InputAction.CallbackContext _){
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mirrorMask);
        // transform.Rotate(rotationAxis, rotationAngle);
        if(didHit){
            transform.Rotate(0f, rotationAngle, 0f);
        }
    }
}