using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Controller : MonoBehaviour
{
    //Initialize and create classes here!
    public Animator animator;
    Rigidbody2D rb2d;
    playerController player1state;
    public bool isAttacking = false; //you're initialized in idle state, so you shouldn't be attacking
    public bool isHurt = false; //call this when making contacting with hitbox
    bool canPressKeys = true; //To create committal actions to player
    public float cooldown;
    gameManager gm;

    [SerializeField]
    float speed = 1.0f;
    //Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
        cooldown = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isHurt", isHurt);

        canPressKeys = true;
        isAttacking = false;
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

        if (isAttacking == false)
        {
            if (Input.GetKeyUp("l"))
            {
                rb2d.velocity = new Vector2(0f, 0f);
                isAttacking = true;
                //cooldown -= Time.deltaTime;
                canPressKeys = false;
                //Recovery();
            }
        }
        /* if (Input.GetKeyUp("d"))
            {
                isAttacking = false;
                canPressKeys = true;
            }
       */
        /*psuedocode:
         * if (collide with otherPlayer.hitbox)
         * {
         *      isHurt = true;
         *      end the match and use gameController to call gameOver state
         * } */

        if (isHurt == true)
        {
            Hurt();
        }
    }

    void Recovery()
    {
        if (cooldown < 1)
        {
            cooldown = 1f;
            isAttacking = false;
            canPressKeys = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "02593") 
        {
            player1state.isHurt = true;
            player1state.Hurt();
        }
    }

    public void Hurt()
    {
            Mathf.Floor((gm.p1Wins++)/2);
            gm.MatchEnd();
        
    }
}

