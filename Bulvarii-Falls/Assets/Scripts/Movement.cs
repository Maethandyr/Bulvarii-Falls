using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference Flip: https://www.youtube.com/watch?v=Cr-j7EoM8bg&ab_channel=DaniKrossing || https://www.youtube.com/watch?v=ccxXxvlS4mI&ab_channel=NickHwang
public class Movement : MonoBehaviour
{
    public float speed = 8; // players move speed
    public bool facingRight = true; // Facing direction
    public bool stance = false;
    public float lerpDuration = 0.5f;

    private float horizontalValue;
    private float VerticalValue;
    private Rigidbody2D rb;
    Vector2 movement;
    float spin;
    bool rotating;

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

    //Helps with the physics of Rigidbody2D
    private void FixedUpdate()
    {
        if (stance == false) //Check Stamina script
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

    public void WhirlpoolDeath()
    {
        
    }

    public IEnumerator WhirlpoolDeathCoroutine()
    {
        //When player fall into whirlpool and lose
        Debug.Log("Whirlpool fall");

        rotating = true;
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 0, 90);
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        rotating = false;
    }
}
