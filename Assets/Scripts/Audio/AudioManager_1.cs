using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_1 : MonoBehaviour
{
    private float _musicVolume=1;                           //                           
    [Range(0, 1)]                                           //
    [SerializeField] float musicVolume;                     //
    private float _sfxVolume=1;                             //
    [Range(0,1)]                                            //
    [SerializeField] float sfxVolume;                       //



    private static AudioSource musicAudioSource;            //
    private static AudioSource sfxAudioSource;              //Variable tipo Audio llamada "sfxAudioSource"

    private static AudioManager_1 _instance;                  //
    public static AudioManager_1 instance                     //
    {                  
        get {                                               //

            if (_instance == null) {                                //

                _instance = FindObjectOfType<AudioManager_1>();       //

                GameObject gameO=null;
                if (_instance == null)                              //
                {
                    gameO = new GameObject("AudioManager");        //
                    gameO.AddComponent<AudioManager_1>();             //
                    _instance = gameO.GetComponent<AudioManager_1>(); //
                  
                }


                if (_instance != null)                                              //
                {
                    var gameMusic = new GameObject("Music");                        //
                    gameMusic.AddComponent<AudioSource>();                          //
                    musicAudioSource = gameMusic.GetComponent<AudioSource>();       //
                    gameMusic.transform.parent = _instance.gameObject.transform;    //
                         var gameSfx = new GameObject("Sfx");                       //
                
                    gameSfx.AddComponent<AudioSource>();                            //

                    gameSfx.transform.parent = _instance.gameObject.transform;      //

                    sfxAudioSource = gameSfx.GetComponent<AudioSource>();           //
                    DontDestroyOnLoad(_instance.gameObject);                        //
                }

            }
            return _instance;                                                       //

        }
    
    }



    public void PlaySfx(AudioClip audioClip) {              //Método para ejecutar el clip "Hit3"
        sfxAudioSource.PlayOneShot(audioClip);              //a la variable "sfxAudioSource" le aplicamos el audioclip enviado desde "HeroController_10" "Hit3"
    }

    public void PlayMusic(AudioClip audioClip)              //
    {
    //    if (audioClip == null)
    //    {
    //        musicAudioSource.Stop();

    //   }
        if (musicAudioSource.clip != audioClip)
        {
            musicAudioSource.clip = audioClip;              //
            musicAudioSource.loop = true;                   //
            musicAudioSource.Play();                        //
        }
    }

    private void Update()
    {
        if (musicVolume != _musicVolume) {                  //
            _musicVolume = musicVolume;                     //
    //        if(musicAudioSource!=null)
            musicAudioSource.volume = musicVolume;          //
        }

        if (sfxVolume != _sfxVolume)                        //
        {
            _sfxVolume = sfxVolume;                         //
    //        if (sfxAudioSource != null)
                sfxAudioSource.volume = musicVolume;        //
        }
    }

}
