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


    public float rotationAngle = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rotateMirrorClockWise.action.performed += TurnClockWise;
        //  rotateMirrorClockWise.action.ReadValue<float>()
        rotateMirrorCounterClockWise.action.performed += TurnCounterClockWise;
    }

    // Update is called once per frame
    void Update()
    {  

    }
    void TurnClockWise(InputAction.CallbackContext _){
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mirrorMask);
        // transform.Rotate(rotationAxis, rotationAngle);
        if(didHit) //&& hit.transform.CompareTag("mirror"))
        {            
            hit.transform.parent.Rotate(0f, rotationAngle, 0f);
        }
    }
    void TurnCounterClockWise(InputAction.CallbackContext _){
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mirrorMask);
        // transform.Rotate(rotationAxis, rotationAngle);
        if(didHit) //&& hit.transform.CompareTag("mirror"))
        {            
            hit.transform.parent.Rotate(0f, -rotationAngle, 0f);
        }
    }
}