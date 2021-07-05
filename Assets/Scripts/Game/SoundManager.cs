using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public List<AudioClip> clips;

    private void Awake()
    {
        instance = GetComponent<SoundManager>();
    }

    public void PlaySound(string clipName, GameObject mainObj)
    {
        AudioSource source = mainObj.GetComponent<AudioSource>();
        source.PlayOneShot(FindAudioClip(clipName));
    }

    private AudioClip FindAudioClip(string clipName)
    {
        for (int i = 0; i < clips.Count; i++)
        {
            if (clips[i].name.Equals(clipName))
            {
                return clips[i];
            }
        }
        return clips[0];
    }
}
