using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {
  public int healthRestore = 20;
  public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);

  public float minScale = 0.95f;
  public float maxScale = 1.05f;
  public float pulseSpeed = 5.0f;

  Vector3 _originalScale;
  AudioSource audioSource;


  void Awake() {
    _originalScale = transform.localScale;
    audioSource = GetComponent<AudioSource>();
  }

  void Start() {}

  void Update() {
    transform.eulerAngles += spinRotationSpeed * Time.deltaTime;


    var pulse = Mathf.Sin(Time.time * pulseSpeed);
    var newScale = Mathf.Lerp(minScale, maxScale, (pulse + 1f) * 0.5f);

    transform.localScale = _originalScale * newScale;
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    var damageable = collision.GetComponent<Damageable>();

    if(damageable) {
      if(damageable.Heal(healthRestore)) {
        if(audioSource) {
          AudioSource.PlayClipAtPoint(audioSource.clip, gameObject.transform.position, audioSource.volume);
        }

        Destroy(gameObject);
      }
    }
  }
}
