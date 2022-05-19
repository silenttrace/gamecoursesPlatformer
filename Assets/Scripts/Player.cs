using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    [SerializeField] float speed = 5.0f;

    [Range(75.0f, 1000.0f)]
    [SerializeField] float jumpForce = 400.0f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(horizontal) >= 1 )
        {
            // we don't want to change y velocity outside of gravity or jump so leave it as it was.
            rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
        }

        var animator = GetComponent<Animator>();
        bool walking = horizontal != 0;
        animator.SetBool("Walk", walking);

        if (horizontal != 0)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = horizontal < 0;
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
