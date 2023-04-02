using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip[] Soundtracks = new AudioClip[4];
    [Header("Snapshots")]
    public AudioMixerSnapshot Paused;
    public AudioMixerSnapshot Unpaused;
    public static Biome CurrentBiome;
    private AudioSource _source;


    public static void SetBiome(Biome biome)
    {
        if (biome != CurrentBiome)
        {
            main._source.clip = main.Soundtracks[(int)biome];
            main._source.Play();
            CurrentBiome = biome;
        }
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

    private void Awake()
    {
        main = this;
        _source = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        GameManager.OnPause += SetPause;
    }
    private void OnDisable()
    {
        GameManager.OnPause -= SetPause;
    }

    private static MusicManager main;
}
