using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SFXData
{
    public string sfxName;
    public AudioClip clip;
}


public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("Music Clips")]
    public AudioClip menuMusic;
    public AudioClip backgroundMusic;
    [Header("Sound Effects")]
    [SerializeField] private List<SFXData> sfxDataList;
    private Dictionary<string, AudioClip> sfxDict;

    protected override void Awake()
    {
        base.Awake();
        sfxDict = new Dictionary<string, AudioClip>();
        foreach (var sfxData in sfxDataList)
        {
            if (!sfxDict.ContainsKey(sfxData.sfxName))
            {
                sfxDict.Add(sfxData.sfxName, sfxData.clip);
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            PlayMusic(menuMusic);
        }
        else
        {
            PlayMusic(backgroundMusic);
        }
    }
    public void PlaySFX(string sfxName)
    {
        if (sfxDict.TryGetValue(sfxName, out AudioClip clip))
        {
            SFXSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"SFX {sfxName} not found!");
        }
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.loop = loop;
            musicSource.Play();
        }
    }
    
}
