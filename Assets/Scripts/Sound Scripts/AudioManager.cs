using UnityEngine.Audio;
// Links Unity Audio name space to this script
using System;
// Loops through sounds to find the correct sound which corresponds to the correct variable
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    // Creates an array for audio to be placed in so that when the AudioManager plays an audio
    // It selects an Audio from the Array
    public static AudioManager instance;

     void Start()
     {
         Play("Game Audio");
         // Plays the Game music upon starting the scene
     }

     void Awake()
    {
        // The audio is played right before the script is activated
        if (instance == null)
         instance = this;
        else
        {
            Destroy(gameObject);
            return;
            // Ensures that there are no duplicate AudioManager objects
        }

         DontDestroyOnLoad(gameObject);
         // When AudioManager is in use the game object cannot be destroyed

         foreach (Sounds s in sounds)
         {
         s.source = gameObject.AddComponent<AudioSource>();
         // Links the AudioSource component to this script
         s.source.clip = s.clip;
         // Creates section where you can drag in the audio you wish to be played
         s.source.volume = s.volume;
         // Creates a slider where  you can modify the volumeo of the audio
         s.source.pitch = s.pitch;
         // Creates a slider where you can modify the pitch of the audio
         s.source.loop = s.loop;
         // Creates a section where you can loop the audio
        }
    }
     public void Play(string name)
     {
         Sounds s = Array.Find(sounds, sounds => sounds.name == name);
         // Searches the Array and plays the audio which corresponds to the audio name
         if (s == null)
             return;
             // Does not play a sound if a sound is not found
             s.source.Play();
             // If the sound is found it will play the sound
     }
}
