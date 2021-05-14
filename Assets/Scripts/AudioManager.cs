using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundClass[] Sounds;


   void Awake ()
    {
        //Add a AudioSource for each sound in the list
        foreach (SoundClass s in Sounds)
        {
           s.Source =  gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.AudioClip;

            s.Source.volume = s.volume;
            s.Source.pitch = s.pitch;
            s.Source.loop = s.Loop;

        }
    }

    
    void Start()
    {
        //plays the music for the game
        Play("MedievalSoundTrack");

    }

    //plays sound in the clip

    public void Play (string name)
    {
        SoundClass s = Array.Find(Sounds, sound => sound.name == name);
        s.Source.Play();
    }
}
