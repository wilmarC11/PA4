using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicaFondo;
    public AudioSource efectos;

    [Header("Clips")]
    public AudioClip sonidoRecoger;
    public AudioClip sonidoVictoria;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (musicaFondo != null && !musicaFondo.isPlaying)
            musicaFondo.Play();
    }

    public void ReproducirRecoger()
    {
        if (efectos != null && sonidoRecoger != null)
            efectos.PlayOneShot(sonidoRecoger);
    }

    public void ReproducirVictoria()
    {
        if (efectos != null && sonidoVictoria != null)
            efectos.PlayOneShot(sonidoVictoria);
    }
}