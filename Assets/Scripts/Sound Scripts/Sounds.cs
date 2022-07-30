using UnityEngine.Audio;
// Links Unity Audio name space to this script
using UnityEngine;

[System.Serializable]
// Allows the modification of sounds in the inspector
// In the inspector you can manage the volume, pitch, and looping of audio
// In the Audio Manager
public class Sounds
{
     public string name;
     // Allows Audio to be named
     // That name is used to reference the audio in the array to play it
     public AudioClip clip;
     // Reference to Audio Clip
     [Range(0f, 1f)]
     // Creates a slider for the volume bar
     public float volume;
     // Allows volume to be modified as a float
     [Range(.1f, 3f)]
     // Creates a slider for the pitch bar
     public float pitch;
     // Allows pitch to be modified as a float
     public bool loop;
     // Allows audio to be looped by clicking a ticking box
     [HideInInspector]
     public AudioSource source;
     // Stores AudioSource as a variable
}
