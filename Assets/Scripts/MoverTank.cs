using UnityEngine;

public class MoverTank : Mover
{
    private Pawn pawn;
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //pawn = GetComponent<Pawn>();
    }

    public override void Move(Vector2 moveDirection, float moveSpeed)
    {
        Vector3 moveVector = new Vector3(moveDirection.x, 0, moveDirection.y) * (moveSpeed * Time.deltaTime);
        moveVector = transform.TransformDirection(moveVector);
        
        rb.MovePosition(rb.position + (moveVector * (moveSpeed * Time.deltaTime)));
    }

    public override void Rotate(Vector2 rotateDirection, float turnSpeed)
    {
        float rotationAmount = rotateDirection.x;
        rotationAmount *= (turnSpeed);
        rotationAmount *= Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }
}
