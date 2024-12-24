using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private CharacterController characterController;

    [SerializeField]
    private float movementSpeed = 5f;
    private float rotationSpeed = 5f;

    public AttackRadius AttackRadius;
    public Canvas inputCanvas;
    public bool isJoystickEnabled;

    private void Start()
    {
        EnableJoystickInput();
    }
    private void OnEnable()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDisable()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void Update()
    {
        if (isJoystickEnabled)
        {
            
            var movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
            characterController.SimpleMove(movementDirection * movementSpeed);
            

            var targetDirection = Vector3.RotateTowards(
                characterController.transform.forward,
                movementDirection,
                rotationSpeed * Time.deltaTime,
                0.0f);

            if (AttackRadius.AttackCoroutine == null)
            {
                characterController.transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        if (gameState == GameState.Gameover)
        {
            DisableJoystickInput();
            Debug.Log("Gameover detected. Joystick disabled.");
        }
    }

    public void EnableJoystickInput()
    {
        isJoystickEnabled = true;
        inputCanvas.gameObject.SetActive(true);
    }

    public void DisableJoystickInput()
    {
        isJoystickEnabled = false;
        //inputCanvas.gameObject.SetActive(false);
    }


}
