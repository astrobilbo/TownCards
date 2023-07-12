using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    public AudioClip[] sounds;
    public AudioSource musicAudioSourcer;

    public AudioClip[] fxBackground;
    public AudioSource backgroundAudioSourcer;

 public AudioClip[] SFX;
    public AudioSource SFXAudioSourcer;
    void Awake()
    {
        if (audioManager==null)
        {
            audioManager=this;
            DontDestroyOnLoad(this.gameObject);
        }    
        else
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        if (!musicAudioSourcer.isPlaying)
        {
            musicAudioSourcer.clip=GetRandom();
            musicAudioSourcer.Play();
        }
      // if (!backgroundAudioSourcer.isPlaying && SceneManager.GetActiveScene().buildIndex>1)
      // {
      //     backgroundAudioSourcer.clip=GetRandomBackground();
      //     backgroundAudioSourcer.Play();
      // }
        if (backgroundAudioSourcer.isPlaying && SceneManager.GetActiveScene().buildIndex<2)
        {
            backgroundAudioSourcer.Stop();
        }
    }
    AudioClip GetRandom()
    {
        return sounds[Random.Range(0,sounds.Length)]; 
    }
   //  AudioClip GetRandomBackground()
   // {
   //     return fxBackground[Random.Range(0,fxBackground.Length)];  
   // }
    public void SFXToca(int index)
    {
        SFXAudioSourcer.clip=SFX[index];
        SFXAudioSourcer.Play();
    }
}
