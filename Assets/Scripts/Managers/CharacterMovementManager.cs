using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    [SerializeField]
    private VariableJoystick joystick;
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private float movementSpeed = 5f;
    private float rotationSpeed = 5f;


    public Canvas inputCanvas;
    public bool isJoystickEnabled;

    private void Start()
    {
        EnableJoystickInput();
    }

    private void Update()
    {
        if (isJoystickEnabled)
        {
            //Debug.Log("Joystick active");
            var movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
            characterController.SimpleMove(movementDirection * movementSpeed);

            var targetDirection = Vector3.RotateTowards(
                characterController.transform.forward,
                movementDirection,
                rotationSpeed * Time.deltaTime,
                0.0f);

            characterController.transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }

    public void EnableJoystickInput()
    {
        isJoystickEnabled = true;
        inputCanvas.gameObject.SetActive(true);
    }


}
