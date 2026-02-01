using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager Instance { get; private set; }

    public AudioSource backgroundMusic;
    public AudioSource SFX;

    public AudioClip dramaMusic;
    public AudioClip mysteryMusic;
    public AudioClip comedyMusic;
    public AudioClip fearMusic;
    public AudioClip bossMusic;
    public AudioClip defaultMusic;

    public AudioClip failSFX;
    public AudioClip rewardSFX;
    public AudioClip attackSFX;
    public AudioClip telonSFX;
    public AudioClip uiSFX;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        PlayMusic(MusicType.Default);
    }

    private void OnEnable()
    {
        MaskManager.OnMaskUpdated += ChangeMaskMusic;
    }

    private void OnDisable()
    {
        MaskManager.OnMaskUpdated -= ChangeMaskMusic;
    }

    public void PlayMusic(MusicType type)
    {
        switch (type)
        {
            case MusicType.Drama:
                backgroundMusic.clip = dramaMusic;
                break;
            case MusicType.Mystery:
                backgroundMusic.clip = mysteryMusic;
                break;
            case MusicType.Comedy:
                backgroundMusic.clip = comedyMusic;
                break;
            case MusicType.Fear:
                backgroundMusic.clip = fearMusic;
                break;
            case MusicType.Boss:
                backgroundMusic.clip = bossMusic;
                break;
        }
        backgroundMusic.Play();
    }

    public void PlaySFX(SFXType type)
    {
        switch (type)
        {
            case SFXType.Fail:
                SFX.pitch = Random.Range(0.8f, 1.2f);
                SFX.PlayOneShot(failSFX);
                break;
            case SFXType.Reward:
                SFX.pitch = Random.Range(0.8f, 1.2f);
                SFX.PlayOneShot(rewardSFX);
                break;
            case SFXType.Attack:
                SFX.pitch = Random.Range(0.8f, 1.2f);
                SFX.PlayOneShot(attackSFX);
                break;
            case SFXType.Telon:
                SFX.pitch = Random.Range(0.8f, 1.2f);
                SFX.PlayOneShot(telonSFX);
                break;
            case SFXType.UI:
                SFX.pitch = Random.Range(0.8f, 1.2f);
                SFX.PlayOneShot(uiSFX);
                break;

        }
    }

    private void ChangeMaskMusic(MaskType newMask)
    {
        switch (newMask)
        {
            case MaskType.Drama:
                PlayMusic(MusicType.Drama);
                break;
            case MaskType.Mystery:
                PlayMusic(MusicType.Mystery);
                break;
            case MaskType.Comedy:
                PlayMusic(MusicType.Comedy);
                break;
            case MaskType.Terror:
                PlayMusic(MusicType.Fear);
                break;
            case MaskType.Default:
                PlayMusic(MusicType.Default);
                break;
        }
    }
}

public enum MusicType
{
    Drama,
    Mystery,
    Comedy,
    Fear,
    Boss,
    Default
}

public enum SFXType
{
    Fail,
    Reward,
    Attack,
    Telon,
    UI
}
