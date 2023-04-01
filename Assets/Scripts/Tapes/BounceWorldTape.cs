public class BounceWorldTape : BaseWorldTape
{
    public override void OnPlayerEnter(Player player)
    {
        // Do player bounce. Make sure bouncing function have cooldown
        // so if collider bug occurs then player won't fly out of the map.
    }
}
