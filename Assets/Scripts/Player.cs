using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float movementSpeed;

    [NonSerialized] public Vector2 rawInput;

    private Rigidbody2D rb;
    private InputAction move;
    private PlayerInput playerInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions.FindAction("Player/Move");
    }

    public void Update()
    {
        rawInput = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity += rawInput * movementSpeed;
    }
}