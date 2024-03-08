using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
[SerializeField] AudioSource audioSource;

 public AudioClip death;
 public AudioClip boostPickup;
 public AudioClip background;

void Start()
    {
        Invoke("StartBG",3);
    }
public void StartBG()
{
    audioSource.clip = background;
    audioSource.loop = true;
    audioSource.volume = 0.3f;
    audioSource.Play();     
}
public void PlaySFX(AudioClip clip)
    {
        audioSource.volume = 0.7f;
        audioSource.PlayOneShot(clip);
    }
}
