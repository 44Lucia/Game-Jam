using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rb2D;

    [SerializeField] float speed;

    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveX, moveY).normalized;

    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
