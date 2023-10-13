using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour {
  public Animator playerAnimator;
  public Animator cameraAnimator;
  public bool shouldControlCameras = true;
  public Canvas canvas;
  public float cutsceneDuration = 11f;

  private bool isCutsceneEnded = false;

  void Start() {

  }

  void Update() {

  }

  void OnTriggerEnter2D(Collider2D collision) {
    if(collision.CompareTag("Player") && !isCutsceneEnded) {
      playerAnimator.SetBool(AnimationStrings.canMove, false);
      canvas.gameObject.SetActive(false);

      Invoke("StopCutscene", cutsceneDuration);
    }
  }

  void StopCutscene() {
    if(shouldControlCameras) {
      cameraAnimator.SetBool(AnimationStrings.cutscene1, false);
    }
    playerAnimator.SetBool(AnimationStrings.canMove, true);
    canvas.gameObject.SetActive(true);

    isCutsceneEnded = true;
  }
}
