using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Smile : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private bool isRight;
    private float speed = 1.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if((transform.position.x > 4.5 && !isRight) || (transform.position.x < -1.5 && isRight))
        {
            Flip();
            speed = -speed;
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        transform.Rotate(0, 180, 0);
    }
}
