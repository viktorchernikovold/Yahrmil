using UnityEngine;

public class BounceWorldTape : BaseWorldTape
{
    public float BounceForce = 500;
    public float timer = 0;
    public void Update()
    {
        timer += Time.deltaTime;
    }

    public override void OnPlayerStay(Player player, ContactPoint2D contact)
    {
        // Do player bounce. Make sure bouncing function have cooldown
        // so if collider bug occurs then player won't fly out of the map.
        if (timer > .2)
        {
            player.UseRigidbody.AddForce(-contact.normal.normalized * BounceForce);
            player.UseRigidbody.AddForce(Physics2D.gravity);
            timer = 0;
        }
    }
}
