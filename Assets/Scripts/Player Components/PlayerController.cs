using UnityEngine;

public class PlayerController : PlayerModule
{
    public bool IsGrounded { get; private set; }
    public float GroundCheckDistance = 0.25f;

    public override void OnFixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance);
        IsGrounded = hit != default;
    }
}
