using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class SoundClass  
{
    public string name;

    public AudioClip AudioClip;


    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool Loop;

    [HideInInspector]
    public AudioSource Source;

}
