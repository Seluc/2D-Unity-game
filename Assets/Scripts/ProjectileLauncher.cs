using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour {
  public GameObject projectilePrefab;
  public Transform launchPoint;

  void Start() { }

  void Update() { }

  public void FireProjectile() {
    var projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation);

    projectile.transform.localScale = new Vector3(projectile.transform.localScale.x * transform.localScale.x > 0 ? 1 : -1, projectile.transform.localScale.y, projectile.transform.localScale.z);
  }
}
