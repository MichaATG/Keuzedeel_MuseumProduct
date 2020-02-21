using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _DontDestroyOnLoad;
    [SerializeField] private bool _RefreshSettingsOnUpdate;
    [SerializeField] private AudioMixerGroup _AudioMixer;

    [Header("Audio")]
    [SerializeField] private List<AudioHandler_Sound> _Sound;

    void Start()
    {
        if (_DontDestroyOnLoad)
            DontDestroyOnLoad(this.gameObject);

        //PlayOnStart
        for (int i = 0; i < _Sound.Count; i++)
        {
            //AudioSource
            if (_Sound[i].AudioSettings.CreateAudioSource)
            {
                _Sound[i].AudioSettings.AudioSource = this.gameObject.AddComponent<AudioSource>();
                _Sound[i].AudioSettings.AudioSource.outputAudioMixerGroup = _AudioMixer;
            }

            //AudioClip
            _Sound[i].AudioSettings.AudioSource.clip = _Sound[i].AudioSettings.AudioClip;

            //Settings
            if (_Sound[i].AudioEffects.PlayOnStart)
            {
                _Sound[i].AudioSettings.AudioSource.playOnAwake = _Sound[i].AudioEffects.PlayOnStart;
                _Sound[i].AudioSettings.AudioSource.Play();
            }
            if (_Sound[i].AudioEffects.FadeIn)
            {
                _Sound[i].AudioSettings.AudioSource.volume = 0;
                _Sound[i].AudioEffects.FadeInSpeed = _Sound[i].AudioEffects.Volume / _Sound[i].AudioEffects.FadeInDuration;
            }
        }

        RefreshSettings();
    }

    void Update()
    {
        if (_RefreshSettingsOnUpdate)
            RefreshSettings();

        for (int i = 0; i < _Sound.Count; i++)
        {
            if (_Sound[i].AudioEffects.FadeIn && !_Sound[i].AudioEffects.FadingDone)
            {
                if (_Sound[i].AudioSettings.AudioSource.volume < _Sound[i].AudioEffects.Volume)
                {
                    _Sound[i].AudioSettings.AudioSource.volume += _Sound[i].AudioEffects.FadeInSpeed * Time.deltaTime;
                }
                else
                {
                    _Sound[i].AudioEffects.FadingDone = true;
                    _Sound[i].AudioSettings.AudioSource.volume = _Sound[i].AudioEffects.Volume;
                }
            }
        }
    }

    public void PlayTrack(string trackname)
    {
        string track = "";
        for (int i = 0; i < _Sound.Count; i++)
        {
            if (_Sound[i].AudioTrackName == trackname)
                AudioHandler_PlayTrack(i);
        }
    }

    private void AudioHandler_PlayTrack(int trackid)
    {
        _Sound[trackid].AudioSettings.AudioSource.Play();
    }

    public void RefreshSettings()
    {
        for (int i = 0; i < _Sound.Count; i++)
        {
            //SetClip
            if (_Sound[i].AudioSettings.AudioSource.clip != _Sound[i].AudioSettings.AudioClip)
                _Sound[i].AudioSettings.AudioSource.clip = _Sound[i].AudioSettings.AudioClip;
            //SetEffects
            if (!_Sound[i].AudioEffects.FadeIn || _Sound[i].AudioEffects.FadeIn && _Sound[i].AudioEffects.FadingDone)
                _Sound[i].AudioSettings.AudioSource.volume = _Sound[i].AudioEffects.Volume;
            _Sound[i].AudioSettings.AudioSource.loop = _Sound[i].AudioEffects.Loop;
        }
    }
}

[System.Serializable]
public class AudioHandler_Sound
{
    public string AudioTrackName;
    public AudioHandler_AudioSettings AudioSettings;
    public AudioHandler_Effects AudioEffects;
}

[System.Serializable]
public class AudioHandler_AudioSettings
{
    [Header("AudioClip")]
    public AudioClip AudioClip;

    [Header("AudioSource")]
    public AudioSource AudioSource;
    public bool CreateAudioSource;
}

[System.Serializable]
public class AudioHandler_Effects
{
    [Header("AudioSettings")]
    [Range(0, 1)] public float Volume = 1;
    public bool Loop;
    public bool PlayOnStart;
    [Header("Fade In/Out")]
    public bool FadeIn;
    public float FadeInDuration;
    public bool FadeOut;
    public bool FadeOutDuration;
    [HideInInspector] public float FadeInSpeed;
    [HideInInspector] public float FadeOutSpeed;
    [HideInInspector] public bool FadingDone;
}