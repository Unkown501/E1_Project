using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float movementx;
    float movementy;
    [SerializeField] float speed = 5.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementDistanceX = movementx * speed * Time.deltaTime;
        float movementDistanceY = movementy * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movementDistanceX, transform.position.y + movementDistanceY);
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementx = v.x;
        movementy = v.y;

        Debug.Log(movementx);
        Debug.Log(movementy);

    }

}
