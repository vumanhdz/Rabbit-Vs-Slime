using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AppleCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Rigidbody2D rb;
    private GameObject Canon;
    void Start()
    {
        Canon = GameObject.FindGameObjectWithTag("Canon");
        float Deg = 200f * Mathf.Deg2Rad;
        if (Canon.transform.rotation.y <= 0)
        {
            Deg = -60f * Mathf.Deg2Rad;
        }

        float vx = speed * Mathf.Cos(Deg);
        float vy = speed * Mathf.Sin(Deg);

        rb.velocity = new Vector2(vx, vy);
    }
    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
