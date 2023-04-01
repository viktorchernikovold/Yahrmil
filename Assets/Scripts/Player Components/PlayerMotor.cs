using UnityEngine;

public class PlayerMotor : PlayerModule
{
    public float MoveSpeed = 2;
    public override void OnFixedUpdate()
    {
        if (Player.GetModule<PlayerController>().IsGrounded)
        {
            float inp = GameInput.Move.x;
            Vector2 mv = new Vector2(inp, 0);
            if (Vector2.Dot(Player.UseRigidbody.velocity, mv) < MoveSpeed)
            {
                Player.UseRigidbody.AddForce(new Vector2(inp, 0), ForceMode2D.Impulse);
            }
        }
    }
}
