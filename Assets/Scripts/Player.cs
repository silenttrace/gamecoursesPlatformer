using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    [SerializeField] float speed = 1.0f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();
        // we don't want to change y velocity outside of gravity or jump so leave it as it was.
        rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
    }
}
