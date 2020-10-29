using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;

    public AudioClip dropEggClip;
    public AudioClip collectingEggClip;
    public AudioClip crackingEgg;
    public AudioClip gameOverClip;
    public AudioClip buttonClip;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayButtonClick()
    {
        audioSource.clip = buttonClip;
        audioSource.Play();
    }
}
