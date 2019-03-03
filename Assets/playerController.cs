using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Initialize and create classes here!
    public Animator animator;
    Rigidbody2D rb2d;
    bool isAttacking = false; //you're initialized in idle state, so you shouldn't be attacking
    bool isHurt = false; //call this when making contacting with hitbox

    [SerializeField]
    float speed = 1.0f;
    //Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("isAttacking", isAttacking);
        if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-speed, 0f);
        }

        if (Input.GetKey("s"))
        {
            rb2d.velocity = new Vector2(speed, 0f);
        }

        if (Input.GetKey("d"))
        {
            isAttacking = true;
            rb2d.velocity = new Vector2(0f, 0f);
        } else if (Input.GetKeyUp("d"))
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
}
