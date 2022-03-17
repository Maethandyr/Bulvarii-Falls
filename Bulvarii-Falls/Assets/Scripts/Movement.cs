using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference Flip: https://www.youtube.com/watch?v=Cr-j7EoM8bg&ab_channel=DaniKrossing || https://www.youtube.com/watch?v=ccxXxvlS4mI&ab_channel=NickHwang
public class Movement : MonoBehaviour
{
    public float speed = 8; // players move speed
    public bool facingRight = true; // Facing direction

    private float horizontalValue;
    private float VerticalValue;
    private Rigidbody2D rb;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed * Time.fixedDeltaTime);
        TurnDirection();
    }

    private void TurnDirection()
    {
        if((movement.x < 0 && facingRight) || (movement.x > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
