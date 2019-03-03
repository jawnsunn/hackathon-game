using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
    //same as playerController only now for player 2!

    //Initialize and create classes here!
    public Animator animator;
    Rigidbody2D rb2d;
    bool isAttacking = false; //you're initialized in idle state, so you shouldn't be attacking
    bool isHurt = false; //call this when making contacting with hitbox
    bool canPressKeys = true; //To create committal actions to player
    private float cooldown;

    [SerializeField]
    float speed = 1.0f;
    //Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        float cooldown = 170f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("isAttacking", isAttacking);
        canPressKeys = true;
        if (Input.GetKey("j"))
        {
            if (canPressKeys == true)
                rb2d.velocity = new Vector2(-speed, 0f);
        }

        if (Input.GetKey("k"))
        {
            if (canPressKeys == true)
                rb2d.velocity = new Vector2(speed, 0f);
        }

        if (cooldown == 10f && isAttacking == false)
        {
            if (Input.GetKey("l"))
            {
                isAttacking = true;
                rb2d.velocity = new Vector2(0f, 0f);
                canPressKeys = false;
                //cooldown -= Time.deltaTime * 100;
            }
        }
        if (Input.GetKeyUp("d"))
        {
            isAttacking = false;
        }

        /*psuedocode:
         * if (collide with otherPlayer.hitbox)
         * {
         *      isHurt = true;
         *      end the match and use gameController to call gameOver state
         * } */
    }

    void Recovery()
    {
        cooldown -= Time.deltaTime;

        if (cooldown == 0)
            cooldown = 0.0f;
    }
}

