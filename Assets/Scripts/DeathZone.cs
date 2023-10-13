using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {
  void Start() {

  }

  void Update() {

  }

  private void OnCollisionEnter2D(Collision2D collision) {
    var damageable = collision.gameObject.GetComponent<Damageable>();
    if(damageable) {
      damageable.Hit(42069, new Vector2(0, 0));
    }
  }
}
