// source code: "https://www.youtube.com/watch?v=i_VFMOTfvmA"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5f;

    [Header("Look Sensitivity")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float upDownRange = 80f;


    [Header("Inputs")]
    [SerializeField] private string horizontalMovement = "Horizontal";
    [SerializeField] private string verticalMovement = "Vertical";

    [SerializeField] private string MouseXInput = "Mouse X";
    [SerializeField] private string MouseYInput = "Mouse Y";

    private Camera mainCamera;
    private float verticalRotation;
    private CharacterController characterController;

    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        float speedVertical = Input.GetAxis(verticalMovement) * walkSpeed;
        float speedHorizontal = Input.GetAxis(horizontalMovement) * walkSpeed;

        Vector3 speed = new Vector3 (speedHorizontal, speedVertical, speedVertical);
        speed = transform.rotation * speed;
    }

    private void HandleRotation()
    {
        float mouseXRotation = Input.GetAxis(MouseXInput) * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= Input.GetAxis(MouseYInput) * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

}