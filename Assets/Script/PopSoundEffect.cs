using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopSoundEffect : MonoBehaviour
{
    System.Random rand;
    AudioSource audiosource;
    [SerializeField] List<AudioClip> clips;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        rand = new System.Random();
    }

    public void PlayPop()
    {
        int r = rand.Next(clips.Count);
        audiosource.PlayOneShot(clips[r]);
    }

}
