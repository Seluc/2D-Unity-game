using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour {
  public float flightSpeed = 2f;
  public float waypointReachedDistance = 0.1f;
  public DetectionZone attackDetectionZone;
  public List<Transform> waypoints;

  Animator animator;
  Rigidbody2D rb;
  Damageable damageable;

  Transform nextWaypoint;
  int waypointNum = 0;

  public bool _hasTarget = false;

  public bool HasTarget {
    get {
      return _hasTarget;
    }
    private set {
      _hasTarget = value;
      animator.SetBool(AnimationStrings.hasTarget, value);
    }
  }

  public bool CanMove {
    get {
      return animator.GetBool(AnimationStrings.canMove);
    }
  }

  void Awake() {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    damageable = GetComponent<Damageable>();
  }

  void Start() {
    nextWaypoint = waypoints[waypointNum];
  }

  void Update() {
    HasTarget = attackDetectionZone.detectedColliders.Count > 0;
  }

  void FixedUpdate() {
    if(damageable.IsAlive) {
      if(CanMove) {
        Flight();
      } else {
        rb.velocity = Vector3.zero;
      }
    }
  }

  private void Flight() {
    var directionToWaypoint = (nextWaypoint.position - transform.position).normalized;
    rb.velocity = directionToWaypoint * flightSpeed;

    UpdateDirection();

    var distance = Vector2.Distance(nextWaypoint.position, transform.position);
    if(distance <= waypointReachedDistance) {
      ++waypointNum;

      if(waypointNum >= waypoints.Count) {
        waypoints.Reverse();
        waypointNum = 0;
      }

      nextWaypoint = waypoints[waypointNum];
    }
  }

  private void UpdateDirection() {
    if(transform.localScale.x > 0) {
      if(rb.velocity.x < 0) {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
      }
    } else {
      if(rb.velocity.x > 0) {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
      }
    }
  }

  public void OnDeath() {
    rb.gravityScale = 2f;
  }
}
