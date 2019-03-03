using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    float speed = 8.0f;
    //Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-speed, 0f);
        }

        if (Input.GetKey("s"))
        {
            rb2d.velocity = new Vector2(speed, 0f);
        }
    }
}
