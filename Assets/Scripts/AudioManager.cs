using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    
    public static AudioManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        foreach (var sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string name) {
        var sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null) {
            Debug.LogError($"sound {name} not found");
            return;
        }

        if (name != "Waddle") {
            Debug.Log($"Playing {name}");
        }
        sound.source.Play();
    }

    public void Stop(string name) {
        var sound = Array.Find(sounds, sound => sound.name == name);
        if (sound == null) {
            Debug.LogError($"sound {name} not found");
            return;
        }
        sound.source.Stop();
    }
}