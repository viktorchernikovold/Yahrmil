using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip[] Soundtracks = new AudioClip[3];
    [Header("Snapshots")]
    public AudioMixerSnapshot Paused;
    public AudioMixerSnapshot Unpaused;

    private void OnEnable()
    {
        GameManager.OnPause += SetPause;
    }
    private void OnDisable()
    {
        GameManager.OnPause -= SetPause;
    }
    public void SetBiome(Biome biome)
    {

    }

    private void SetPause(bool value)
    {
        switch (value)
        {
            case true:
                Paused.TransitionTo(0);
                break;
            case false:
                Unpaused.TransitionTo(0);
                break;
        }
    }
}
