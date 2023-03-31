using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModuleControl : PlayerModule
{
    public bool facingLeft;

    public override void OnUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > .5)
        {
            facingLeft = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.5)
        {
            facingLeft = false;
        }
    }

    public override void OnFixedUpdate()
    {
        if (facingLeft)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (!facingLeft)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
