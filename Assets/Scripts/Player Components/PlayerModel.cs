using UnityEngine;

public class PlayerModel : PlayerModule
{
    public bool FacingRight = true;

    public override void OnUpdate()
    {
        // use an EPSILON damnit!!
        if (Input.GetAxisRaw("Horizontal") > float.Epsilon)
        {
            FacingRight = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < -float.Epsilon)
        {
            FacingRight = false;
        }
        transform.localScale = new Vector2(FacingRight ? 1 : -1, 1);
    }
}
