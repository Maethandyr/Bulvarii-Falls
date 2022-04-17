using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public float pullSpeed = 1;
    public float rangeDetection;
    public float escapeDifficulty;
    public float deathTimer = 5; //Used in public inspector to set max timer, should not be change in code
    [Range(0f, 1f)]
    public float setOpaque = 0; //Used to set opaque (invisibility) of a sprite
    public GameObject player;

    private float staminaConsumeCount;
    private float maxDeathTimer; //Used as a timer for death, use it as a countdown
    private GameObject pullObject;
    private SpriteRenderer whirlpoolRenderer;
    private Transform target;
    private Rigidbody2D targetrb;
    private Movement playerMovement;
    private Stamina stamina;
    private StaminaUI staminaUI;
    private bool isDeathTimer;
    CircleCollider2D m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Player object must have tag "Player"
        targetrb = target.GetComponent<Rigidbody2D>();
        whirlpoolRenderer = gameObject.GetComponent<SpriteRenderer>();
        whirlpoolRenderer.color = new Color(1, 1, 1, setOpaque);
        //Player Gameobject with script Movement
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        stamina = GameObject.FindGameObjectWithTag("Player").GetComponent<Stamina>();
        staminaUI = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<StaminaUI>();
        pullObject = null;
        isDeathTimer = false;
        maxDeathTimer = deathTimer;
        staminaConsumeCount = 0;

        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<CircleCollider2D>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        //Output this data into the console
        OutputData();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        if (pullObject != null && isDeathTimer)
        {
            targetrb.AddForce((m_Center - target.position) * pullSpeed);
            EscapeAttempt();
            
        }
        else if (isDeathTimer == false)
        {
            pullObject = null;
        }

        //Just find that while loop in update break the game
    }

    public void DetectPlayer()
    {
        //Checking distance to player and stopping distance to player
        if (Vector2.Distance(transform.position, target.position) < rangeDetection)
        {
            //Debug.Log("Player Detected at: " + Vector2.Distance(transform.position, target.position)/rangeDetection + setOpaque);
            //Detecting player by calculating distance and divide by rangeDetection division. The color set the opaque. Plus set opaque add in how much it suppose to be visible
            whirlpoolRenderer.color = new Color(1, 1, 1, 1 - Vector2.Distance(transform.position, target.position) / rangeDetection + setOpaque);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Player is dead");
            //staminaUI.SetEnergy(stamina.maxStamina);
            pullObject = collision.gameObject;
            playerMovement.whirlpoolRotating = true;
        }

        if (isDeathTimer == false)
        {
            //StartCoroutine(WhirlpoolDeathCoroutine(deathTimer));
            isDeathTimer = true;
            SetWhirlpoolDeathTimer();
            SetEscapeAttempt();
        }
    }

    void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + m_Center);
        Debug.Log("Collider Size : " + m_Size);
        Debug.Log("Collider bound Minimum : " + m_Min);
        Debug.Log("Collider bound Maximum : " + m_Max);
    }

    //To make sure player doesn't fall into it again shortly
    public IEnumerator AfterEscapeCoroutine(float timer)
    {
        Debug.Log("Whirlpool Disable");
        m_Collider.enabled = false;
        //yield on a new YieldInstruction that waits.
        yield return new WaitForSeconds(timer);
        Debug.Log("Whirlpool Enable");
        m_Collider.enabled = true;
    }

    public void SetWhirlpoolDeathTimer()
    {
        maxDeathTimer = deathTimer;
    }

    public void SetEscapeAttempt()
    {
        staminaConsumeCount = 0;
    }

    public void EscapeAttempt()
    {
        //Escaping is related to the amount of stamina consume
        if (staminaConsumeCount < escapeDifficulty && isDead == false) 
        {
            if (Input.GetKeyDown("space") && stamina.stamina > 0)
            {
                Debug.Log("I'm stuck");
                stamina.stamina -= 1;
                staminaConsumeCount += 1;
            }
        }
        else if (staminaConsumeCount >= escapeDifficulty && isDead == false)
        {
            Debug.Log("I'm Free!");
            isDeathTimer = false;
            StartCoroutine(AfterEscapeCoroutine(1)); //Just to make sure player doesn't fall into whirlpool shortly, not needed
        }

        if (maxDeathTimer > 0 && isDeathTimer)
        {
            maxDeathTimer -= Time.deltaTime;
            Debug.Log("Tick Tock: " + maxDeathTimer);
        }
        else if (maxDeathTimer <= 0 && isDeathTimer)
        {
            //Debug.Log("Whirlpool, oh no. The player is now friend with Whirlpool!");
            isDead = true;
            playerMovement.WhirlpoolDeath();
            gameObject.GetComponent<Movement>().enabled = false;

        }
    }
}
