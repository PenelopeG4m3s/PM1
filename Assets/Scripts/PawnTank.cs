using UnityEngine;

public class PawnTank : Pawn
{
    public override void Start()
    {
        // Save my tank in my GameManager
        GameManager.instance.tanks.Add(this);

        // Do what all pawns do
        base.Start();
    }

    public void OnDestroy()
    {
        // Remove my tank from the GameManager list
        GameManager.instance.tanks.Remove(this);
    }

    public override void Move(Vector3 directionToMove)
    {
        mover.Move(directionToMove, moveSpeed);
    }

    public override void Rotate(Vector3 directionToRotate)
    {
        mover.Rotate(directionToRotate, turnSpeed);
    }

    public override void Shoot()
    {
        Debug.Log("Pew pew pew");
    }
}
