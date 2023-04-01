using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public abstract class BaseWorldTape : MonoBehaviour
{
    public Vector2 Beginning;
    public Vector2 End;
    private LineRenderer lRenderer;
    private EdgeCollider2D eCollider;

    public virtual void OnPlayerEnter(Player player) { }
    public virtual void OnPlayerStay(Player player) { }
    public virtual void OnPlayerExit(Player player) { }

    public void UpdateLine()
    {
        if (lRenderer.positionCount != 2)
        {
            lRenderer.positionCount = 2;
        }
        lRenderer.SetPosition(0, transform.position + (Vector3)Beginning);
        lRenderer.SetPosition(1, transform.position + (Vector3)End);
    }
    public void UpdateCollider()
    {
        List<Vector2> points = new();
        points.Add(Beginning);
        points.Add(End);
        eCollider.SetPoints(points);
    }

    private void Awake()
    {
        lRenderer = GetComponent<LineRenderer>();
        eCollider = GetComponent<EdgeCollider2D>();
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        Awake();
        UpdateLine();
        UpdateCollider();
    }
#endif
}

