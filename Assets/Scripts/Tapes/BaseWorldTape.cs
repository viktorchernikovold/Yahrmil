using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public abstract class BaseWorldTape : MonoBehaviour
{
    public Vector2 Beginning
    {
        get => _beginning;
        set
        {
            _beginning = value - (Vector2)transform.position;
        }
    }
    public Vector2 End
    {
        get => _ending;
        set
        {
            _ending = value - (Vector2)transform.position;
            UpdateLine();
            UpdateCollider();
        }
    }
    private Vector2 _beginning;
    private Vector2 _ending;
    private LineRenderer _renderer;
    private EdgeCollider2D _collider;

    public virtual void OnPlayerEnter(Player player, ContactPoint2D contact) { }
    public virtual void OnPlayerStay(Player player, ContactPoint2D contact) { }
    public virtual void OnPlayerExit(Player player, ContactPoint2D contact) { }
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public void UpdateLine()
    {
        if (_renderer.positionCount != 2)
        {
            _renderer.positionCount = 2;
        }
        _renderer.SetPosition(0, transform.position + (Vector3)Beginning);
        _renderer.SetPosition(1, transform.position + (Vector3)End);
    }
    public void UpdateCollider()
    {
        List<Vector2> points = new();
        points.Add(Beginning);
        points.Add(End);
        _collider.SetPoints(points);
    }

    #region Unity callbacks
    private void Awake()
    {
        _renderer = GetComponent<LineRenderer>();
        _collider = GetComponent<EdgeCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D p in collision.contacts)
        {
            if (p.collider.CompareTag("Player"))
            {
                Player pl = p.collider.GetComponent<Player>();
                OnPlayerEnter(pl, p);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D p in collision.contacts)
        {
            if (p.collider.CompareTag("Player"))
            {
                Player pl = p.collider.GetComponent<Player>();
                OnPlayerStay(pl, p);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (ContactPoint2D p in collision.contacts)
        {
            if (p.collider.CompareTag("Player"))
            {
                Player pl = p.collider.GetComponent<Player>();
                OnPlayerExit(pl, p);
            }
        }
    }
    #endregion
#if UNITY_EDITOR
    private void OnValidate()
    {
        Awake();
        UpdateLine();
        UpdateCollider();
    }
    #endif
}

