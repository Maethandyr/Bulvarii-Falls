using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kusaseachi : MonoBehaviour
{
    public float stopDistance = 5;
    public float MoveSpeed = 5;
    public bool facingRight = true; // Facing direction

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Player object must have tag "Player"
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        TurnDirection();
    }

    public void FollowPlayer()
    {
        //Stopping distance to player
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
        }
    }

    private void TurnDirection()
    {
        if ((target.position.x < 0 && facingRight) || (target.position.x > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
