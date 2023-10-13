using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrigger : MonoBehaviour {
  public FadeEffect screenFade;

  AudioSource audioSource;


  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")) {
      screenFade.StartCoroutine(screenFade.FadeOut(5f));

      if(audioSource) {
        audioSource.Play();
      }
    }
  }
}
