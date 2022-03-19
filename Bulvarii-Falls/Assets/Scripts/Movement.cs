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
    private Stamina stamina;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        stamina = gameObject.GetComponent<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }

    //Helps with the physics of Rigidbody2D
    private void FixedUpdate()
    {
        if (stamina.stance == false) //Check Stamina script
        {
            rb.AddForce(movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity -= 0.1f * rb.velocity; //Refence slowdown: https://answers.unity.com/questions/1683005/how-to-make-an-object-slowly-decelerate.html
        }
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
