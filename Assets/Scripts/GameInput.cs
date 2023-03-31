using UnityEngine;

public static class GameInput
{
    public static Vector2 Move => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    public static Vector2 Look => new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
}
