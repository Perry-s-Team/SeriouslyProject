using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    private new Rigidbody2D rigidbody;

    public bool canMove = true;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Moving();
        }
    }

    private void Moving()
    {
        Vector2 inputVector = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputVector = inputVector.normalized;
        rigidbody.MovePosition(rigidbody.position + inputVector * (playerSpeed * Time.fixedDeltaTime));
    }

    public void FrezeMoving()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
    }

    public void UnFrezeMoving()
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;
    }
}
