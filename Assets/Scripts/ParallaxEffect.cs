using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {
  [SerializeField] private Camera cam;
  [SerializeField] Transform followTarget;

  private Vector2 startingPosition;

  private float startingZ;

  private Vector2 camMoveSinceStart => (Vector2) cam.transform.position - startingPosition;

  private float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

  private float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane)); 

  private float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

  void Start() {
    startingPosition = transform.position;
    startingZ = transform.position.z;
  }

  void Update() {
    var newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

    transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
  }
}
