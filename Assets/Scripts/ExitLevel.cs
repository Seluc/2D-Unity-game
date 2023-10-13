using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {
  public FadeEffect screenFade;
  public bool needFade = false;
  public float fadeDuration = 1f;
  public float delay = 0f;

  AudioSource audioSource;


  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void Start() {}

  void Update() {}

  private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.CompareTag("Player")) {
      if(audioSource) {
        audioSource.Play();
      }

      if(needFade) {
        screenFade.StartCoroutine(screenFade.FadeOut(fadeDuration));
      }

      Invoke("LoadNewLevel", delay);
    }
  }

  void LoadNewLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
