using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour {
    public AudioManager instance;
    public AudioFile[] audioFiles;

    private float timeToReset;
    private bool timerIsSet = false;
    private string tmpName;
    private float tmpVol;

    // Use this for initialization
    void Awake() {
        if (instance == null) {
            instance = this;
        }

        else if (instance != this) {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
        foreach (var s in audioFiles) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
        }

    }

    public void PlaySound(string name) {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);
        if (s == null) {
            Debug.LogError("Sound name" + name + "not found!");
            return;
        } else {
            if (s.pitchVariation > 0)
                s.source.pitch = 1f + UnityEngine.Random.Range(-s.pitchVariation, s.pitchVariation);
            s.source.Play();
        }
    }

    public void StopSound(String name) {
        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

        if (s == null) {
            Debug.LogError("Sound name" + name + "not found!");
            return;
        } else {
            s.source.Stop();
        }
    }

    public static IEnumerator StartFade(AudioSource music, float duration, float targetVol) {
        float currentTime = 0;
        float start = music.volume;

        while(currentTime < duration){
            currentTime += Time.deltaTime;
            music.volume = Mathf.Lerp(start, targetVol, currentTime/duration);
            yield return null;
        }
        yield break;
    }
}