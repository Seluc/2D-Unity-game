using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
  public Slider healthSlider;
  public TMP_Text healthText;

  Damageable playerDamageable;

  void Awake() {
    playerDamageable = GameObject.FindGameObjectWithTag("Player").GetComponent<Damageable>();
  }

  void Start() {
    healthSlider.value = playerDamageable.Health / playerDamageable.MaxHealth;
    healthText.text = playerDamageable.Health.ToString();
  }

  private void OnEnable() {
    playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
  }

  private void OnDisable() {
    playerDamageable?.healthChanged.RemoveListener(OnPlayerHealthChanged);
  }

  private void OnPlayerHealthChanged(float newHealth, float maxHealth) {
    healthSlider.value = newHealth / maxHealth;
    healthText.text = newHealth.ToString();
  }

  void Update() {}
}
