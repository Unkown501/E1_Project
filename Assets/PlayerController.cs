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
    [SerializeField] float dashSpeed = 30f;
    [SerializeField] float dashTime = 0.9f;

    float lastDir = 1f;
    bool isDashing = false;
    Animator animator;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (isDashing) return;

        rb.linearVelocity = new Vector2(movementx * speed, rb.linearVelocity.y);
        if(!Mathf.Approximately(movementx,0f))
        {
            animator.SetBool("is_running",true);
            spriteRenderer.flipX = movementx<0;
        }else{
            animator.SetBool("is_running",false);
        }

        if (movementx != 0)
        {
            lastDir = Mathf.Sign(movementx);
        }

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
    void OnDash(){
        if (!isDashing)
            StartCoroutine(DashRoutine());
    }
    System.Collections.IEnumerator DashRoutine()
    {
        isDashing = true;

        float dir = (movementx != 0) ? Mathf.Sign(movementx) : lastDir;

        float oldGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        rb.linearVelocity = new Vector2(dir * dashSpeed, 0f);

        yield return new WaitForSeconds(dashTime);

        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        rb.gravityScale = oldGravity;

        isDashing = false;
    }
}
