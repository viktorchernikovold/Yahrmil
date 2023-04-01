using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TapeVertex : MonoBehaviour
{
    public bool Rotate = false;
    public bool Visible => _renderer.enabled;
    public const float RotateSpeed = 20f;
    private SpriteRenderer _renderer;

    public void SetPosition(Vector2 localPos)
    {
        transform.localPosition = localPos;
    }
    public void Show()
    {
        _renderer.enabled = true;
    }
    public void Hide()
    {
        _renderer.enabled = false;
    }
    public void SetColor(Color c)
    {
        _renderer.color = c;
    }
    private void Update()
    {
        switch (Rotate)
        {
            case true:
                transform.Rotate(new Vector3(0, 0, RotateSpeed * Time.deltaTime));
                return;
            case false:
                transform.eulerAngles = Vector3.zero;
                return;
        }
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        Hide();
    }
}
