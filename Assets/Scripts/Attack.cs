using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
  Collider2D attackCollider;
  public int attackDamage = 10;
  public Vector2 knockback = Vector2.zero;

  void Awake() {
    attackCollider = GetComponent<Collider2D>();
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    Damageable damageable = collision.GetComponent<Damageable>();
    if(damageable != null) {
      damageable.Hit(attackDamage, transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y));
    }
  }
}
