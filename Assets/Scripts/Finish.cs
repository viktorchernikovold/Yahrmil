using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Finish : MonoBehaviour
{
    private BoxCollider2D _collider;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _collider.enabled = false;
            GameManager.FinishLevel();
        }
    }
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
}
