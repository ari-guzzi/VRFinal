using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Jump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
     [SerializeField] private InputActionReference rightTrigger;
     [SerializeField] private InputActionReference leftTrigger;
     [SerializeField] private InputActionReference rightGrip;
     [SerializeField] private InputActionReference leftGrip;

    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    //private rigidbody rb;
    private void Awake() => _characterController = GetComponent<CharacterController>();

    private void OnEnable() => jumpButton.action.performed += Jumping;
    private void OnDisable() => jumpButton.action.performed -= Jumping;

public bool testJump = false;
    private void Jumping(InputAction.CallbackContext obj)
    {
        if (!_characterController.isGrounded) return;
        _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

    }
    private void JumpingTest()
    {
        if (!_characterController.isGrounded) return;
        _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

    }

    // Update is called once per frame
    private void Update()
    {
        if(testJump){
            JumpingTest();
            testJump = false;
        }
        if (_characterController.isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        _playerVelocity.y += gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);

        float rightValue = rightTrigger.action.ReadValue<float>();
        float leftValue = leftTrigger.action.ReadValue<float>();
        float right1Value = rightGrip.action.ReadValue<float>();
        float left2Value = leftGrip.action.ReadValue<float>();
        if(rightValue > 0.5f && leftValue > 0.5f && right1Value > 0.5f && left2Value > 0.5f)  {
           SceneManager.LoadScene("MainScene");
           Debug.Log("restart");
        }
    }
}