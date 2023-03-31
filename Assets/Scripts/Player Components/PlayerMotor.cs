using UnityEngine;

public class PlayerMotor : PlayerModule
{
    public float MoveSpeed = 2;
    public override void OnFixedUpdate()
    {
        Vector2 vel = Player.UseRigidbody.velocity;
        vel.x = GameInput.Move.x * MoveSpeed;
        Player.UseRigidbody.velocity = vel;
    }
}
