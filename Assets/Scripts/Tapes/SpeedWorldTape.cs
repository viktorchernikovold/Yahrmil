using UnityEngine;
using System;

public class SpeedWorldTape : BaseWorldTape
{
    public float MaxSpeedMultiplier = 2;
    public float Acceleration = 100f;
    public override void OnPlayerStay(Player player, ContactPoint2D contact)
    {
        int s = Math.Sign(GameInput.Move.x);
        if (s != 0)
        {
            Vector2 dir = Quaternion.Euler(0, 0, 45f * s) * contact.normal;
            if (Mathf.Abs(Vector2.Dot(player.UseRigidbody.velocity, dir)) < player.Motor.MoveSpeed * MaxSpeedMultiplier)
            {
                player.UseRigidbody.AddForce(dir * Acceleration);
            }
        }
        // Accelerate the player if it moves.
    }
}
