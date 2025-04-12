using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveDir;
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //Anima.SetFloat("horizontal", moveX);
        //Anima.SetFloat("vertical", moveY);

        moveDir = new Vector2(moveX, moveY).normalized;

        rb.velocity = moveDir * moveSpeed;
    }
}
