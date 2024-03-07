using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager :Singleton<SoundManager>
{
    private AudioSource source;
    public List<AudioClip> SfxSounds = new List<AudioClip>();

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySfxSound(string str)
    {

        var sound = SfxSounds.FirstOrDefault(obj => obj.name == str);
        source.PlayOneShot(sound);
        source.volume = PlayerPrefsManager.Instance.SfxVolume;
        source.loop = false;
    }
    public void PlaySfxSoundWIthRequiredVol(string str,float volume)
    {
        var sound = SfxSounds.FirstOrDefault(obj => obj.name == str);
        source.PlayOneShot(sound);
        if(PlayerPrefsManager.Instance.SfxVolume>0){source.volume = volume;}
        source.loop = false;
    }

    public void SetVolumeOnStart(AudioSource source)
    {
        source.volume = PlayerPrefsManager.Instance.SfxVolume;
    }
    public void StopSound(float t)
    {
       Invoke(nameof(stop),t);
    }

    void stop()
    {
         source.Stop();
    }
    
}
