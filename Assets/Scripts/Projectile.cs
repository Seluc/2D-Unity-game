using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  public int damage = 5;
  public Vector2 knockback = Vector2.zero;
  public Vector2 moveSpeed = new Vector2(12f, 0);
  public float destroyDistance = 20f;

  private Vector3 startPosition;

  Rigidbody2D rb;


  private void Awake() {
    rb = GetComponent<Rigidbody2D>();
  }

  void Start() {
    startPosition = transform.position;

    rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
  }

  void Update() {
    if(gameObject.transform.position.x > startPosition.x + destroyDistance || gameObject.transform.position.x < startPosition.x - destroyDistance) {
      Debug.Log("Arrow destroyed withoit hitting anyone");

      Destroy(gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    var damageable = collision.GetComponent<Damageable>();

    if(damageable != null) {
      if(damageable.Hit(damage, transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y))) {
        Destroy(gameObject);
      }
    }
  }
}
