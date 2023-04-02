using UnityEngine;
using UnityEngine.UI;

public class uGUI_MenuBackground : MonoBehaviour
{
    public AnimationCurve FlashSequence;
    public Image FlashingImage;

    private void FixedUpdate()
    {
        UpdateFlashing();
    }
    private void UpdateFlashing()
    {
        Color c = Color.white;
        c.a = FlashSequence.Evaluate(Time.time);
        FlashingImage.color = c;
    }
}
