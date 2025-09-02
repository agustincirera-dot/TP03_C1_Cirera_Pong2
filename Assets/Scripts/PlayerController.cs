using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public float speed = 5f;
    public float minY = -3.5f;
    public float maxY = 3.5f;

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(upKey)) move = 1f;
        if (Input.GetKey(downKey)) move = -1f;

        Vector3 pos = transform.position;
        pos.y += move * speed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY); // limitar dentro de la cancha
        transform.position = pos;
    }

    // Opciones simples
    public void SetHeight(float newHeight)
    {
        Vector3 scale = transform.localScale;
        scale.y = newHeight;
        transform.localScale = scale;
    }

    public void SetColor(Color c)
    {
        GetComponent<SpriteRenderer>().color = c;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

}
