using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundRandom : MonoBehaviour {

    [Header("Sound effects")]
    public AudioClip[] clips;
    public AudioSource audioSource;

    public float PitchMin = 0.8f;
    public float PitchMax = 1.2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound ()
    {
        if (!audioSource.isPlaying)
        {
            int i = Random.Range(0, clips.Length);

            audioSource.clip = clips[i];
            audioSource.pitch = Random.Range(PitchMin, PitchMax);
            audioSource.Play();
        }
    }
}
