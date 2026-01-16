using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float movementx;
    float movementy;
    [SerializeField] float speed = 5.0f;
    Rigidbody2D rb;
    bool onGround;
    int score = 0;
     [SerializeField] int jumpforce = 300;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float movementDistanceX = movementx * speed * Time.deltaTime;
        float movementDistanceY = movementy * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movementDistanceX, transform.position.y + movementDistanceY);*/
        rb.linearVelocity = new Vector2(movementx * speed, rb.linearVelocity.y);
        if (onGround && movementy > 0)
        {
            rb.AddForce(new Vector2(0, jumpforce));
        }
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementx = v.x;
        movementy = v.y;

        Debug.Log(movementx);
        Debug.Log(movementy);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = true;
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            onGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("collectible"))
        {
            score++;
            other.gameObject.SetActive(false);
            Debug.Log("socre:" + score);
        }
    }
}
