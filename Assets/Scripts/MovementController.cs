using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] int speed;
    float speedMultiplier;

    [Range(1,10)]
    [SerializeField] float acceleration;

    bool buttonPressed;

    bool isWallTouched;
    public LayerMask wallLayer;
    public Transform wallCheckPoint;

    Vector2 relativeTransform;

    public bool isOnPlatform;
    public Rigidbody2D platformRb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        UpdateRelativeTransform();
    }

    private void FixedUpdate()
    {
        UpdateSpeedMutliplier();

        float targetspeed = speed * speedMultiplier * relativeTransform.x;

        if (isOnPlatform) 
        {
            rb.velocity = new Vector2(targetspeed+platformRb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(targetspeed, rb.velocity.y);
        }

        isWallTouched = Physics2D.OverlapBox(wallCheckPoint.position, new Vector2(0.6f, 0.5f), 0, wallLayer);

        if (isWallTouched)
        {
            Flip();
        }
    }

    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        UpdateRelativeTransform();
    }

    void UpdateRelativeTransform()
    {
        relativeTransform = transform.InverseTransformVector(Vector2.one);
    }

    public void Move(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            buttonPressed = true;
        }
        else if (value.canceled)
        {
            buttonPressed = false;
        }
    }

    void UpdateSpeedMutliplier()
    {
        if (buttonPressed && speedMultiplier < 1) 
        {
            speedMultiplier += Time.deltaTime * acceleration; 
        }
        else if (!buttonPressed && speedMultiplier > 0)
        {
            speedMultiplier -= Time.deltaTime * acceleration;
            if (speedMultiplier < 0) speedMultiplier = 0;
        }
    }

}