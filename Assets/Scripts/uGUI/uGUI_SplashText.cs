using UnityEngine;

public class uGUI_SplashText : MonoBehaviour
{
    public float Frequency;
    public float Amplitude;
    private RectTransform _transform;

    private void Update()
    {
        Vector3 scale = Vector3.one;
        float a = Mathf.Cos(Time.time * Frequency) * Amplitude;
        scale.x += a;
        scale.y += a;
        scale.z += a;
        _transform.localScale = scale;
    }
    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }
}
