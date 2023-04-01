using UnityEngine;

public class AccelerateWorldTape : BaseWorldTape
{
    public float MaxAccelerateRate = 2;
    public override void OnPlayerStay(Player player, ContactPoint2D contact)
    {
        // Accelerate the player if it moves.
    }
}
