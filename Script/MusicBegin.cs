using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBegin : MonoBehaviour
{
    public List<AudioClip> AudioList;
    AudioSource audioSource;

	void Start () {
        int i = Random.Range(0, AudioList.Count);
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = AudioList[i];
        audioSource.Play();
	}
	
	void Update () {
		
	}
}
