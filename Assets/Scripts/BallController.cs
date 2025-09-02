using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 6f;
    public float speedIncreaseTime = 0.2f;
    public float speedIncreaseBounce = 0.5f;

    private float speed;
    private Vector2 dir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; //evita atravesar colliders
        rb.gravityScale = 0; //asegura que no caiga
        speed = startSpeed;
        Launch();
    }

    void Update()
    {
        speed += speedIncreaseTime * Time.deltaTime;
        rb.velocity = dir * speed; //ahora movemos con física
    }

    void Launch()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        dir = new Vector2(x, y).normalized;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        dir = Vector2.Reflect(dir, col.contacts[0].normal).normalized;
        speed += speedIncreaseBounce;
        rb.velocity = dir * speed; //actualizamos velocidad después del rebote
    }

    public void ResetBall(Vector2 pos)
    {
        transform.position = pos;
        speed = startSpeed;
        Launch();
        rb.velocity = dir * speed;
    }
}
