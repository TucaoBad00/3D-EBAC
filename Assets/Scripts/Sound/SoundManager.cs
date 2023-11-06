using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sFXSetups;

    public AudioSource musicSource;

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }
    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }
    public SFXSetup GetSFXByType(SFXTypes sFXTypes)
    {
        return sFXSetups.Find(i => i.sFXSTypes == sFXTypes);
    }
}
public enum MusicType
{
    TYPE_1,
    TYPE_2,
    TYPE_3
}
[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXTypes
{
    TYPE_1,
    TYPE_2,
    TYPE_3
}
[System.Serializable]
public class SFXSetup
{
    public SFXTypes sFXSTypes;
    public AudioClip audioClip;
}




