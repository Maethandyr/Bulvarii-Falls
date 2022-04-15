using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference Flip: https://www.youtube.com/watch?v=Cr-j7EoM8bg&ab_channel=DaniKrossing || https://www.youtube.com/watch?v=ccxXxvlS4mI&ab_channel=NickHwang
public class Movement : MonoBehaviour
{
    public float speed = 800f; // players move speed
    public float rotationSpeed = 500f;
    public float sinkSpeed = 500f;
    [Range(0.0f, 0.1f)]
    public float skid = 0.01f;
    public bool facingRight = true; // Facing direction
    [HideInInspector]
    public bool stance = false;
    [HideInInspector]
    public bool whirlpoolRotating = false;

    private Rigidbody2D rb;
    Vector2 movement;
    Vector3 scaleChange;
    private Stamina stamina;
    private RestartLevel restartLevel;
    private GameObject gameManager;

    private void Awake()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        stamina = gameObject.GetComponent<Stamina>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        restartLevel = gameManager.GetComponent<RestartLevel>();
        stance = false;
        whirlpoolRotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //WhirlpoolDeath();
    }

    //Helps with the physics of Rigidbody2D
    private void FixedUpdate()
    {
        if (stance == false) //Check Stamina script
        {
            rb.AddForce(movement * speed * Time.fixedDeltaTime);
            rb.velocity -= skid * rb.velocity;
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
        if (whirlpoolRotating)
        {
            transform.Rotate(new Vector3(0f, 0f, rotationSpeed) * Time.deltaTime);
            if (transform.localScale.x > 0 || transform.localScale.y > 0)
            {
                transform.localScale += scaleChange * sinkSpeed * Time.deltaTime;
            }
            else
            {
                restartLevel.GameOverScene();
            }
        }
    }
}
