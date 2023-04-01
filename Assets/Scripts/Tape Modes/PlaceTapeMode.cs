using UnityEngine;

public class PlaceTapeMode : BaseTapeMode
{
    private BaseWorldTape currentTape;
    private byte progress = 0;
    public override void Shoot(Vector2 mousePosWp)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos, mousePosWp - pos, 5f);
        if (hit != default(RaycastHit2D))
        {
            if (progress == 0)
            {
                currentTape = Instantiate(tapePrefab, transform.position, Quaternion.identity);
                currentTape.Beginning = hit.point - (Vector2)currentTape.transform.position;
                progress++;
            }
            else if (progress == 1) 
            {

                currentTape.End = hit.point - (Vector2)currentTape.transform.position;
                currentTape.UpdateLine();
                currentTape.UpdateCollider();
                progress = 0;
                currentTape = null;
            }
        }
        // spawn tape on tile.
    }
}
