using UnityEngine;

public class PlaceTapeMode : BaseTapeMode
{
    public override void Shoot(Vector2 mousePosWp)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, mousePosWp - pos, MaxDistance);
        if (hit != default(RaycastHit2D))
        {
            switch (Progress)
            {
                case 0:
                    Begin(hit.point);
                    break;
                case 1:
                    End(hit.point);
                    break;
            }
        }
        else if (Progress == 1)
        {
            Interrupt();
        }
    }
    public override void Begin(Vector2 pos)
    {
        CurrentTape = Instantiate(tapePrefab, pos, Quaternion.identity);
        Progress = 1;
        CurrentTape.Beginning = pos;
    }
    public override void End(Vector2 pos)
    {
        CurrentTape.End = pos;
        int wl = Mathf.FloorToInt(Vector2.Distance(CurrentTape.Beginning, CurrentTape.End));
        if (wl > Length)
        {
            Interrupt();
        }
        else
        {
            int old = Length;
            Length -= wl;
            Progress = 0;
            CurrentTape = null;
        }
    }
    public override void Interrupt()
    {
        Progress = 0;
        CurrentTape.Destroy();
        CurrentTape = null;
    }
}
