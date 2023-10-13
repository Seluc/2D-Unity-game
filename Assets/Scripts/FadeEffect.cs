using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour {
  public Image fadePanel;


  private void Start() {
    var panelColor = fadePanel.color;
    panelColor.a = 0f;
    fadePanel.color = panelColor;
  }

  public IEnumerator FadeOut(float fadeDuration) {
    var panelColor = fadePanel.color;
    float elapsedTime = 0;

    while(elapsedTime < fadeDuration) {
      elapsedTime += Time.deltaTime;

      panelColor.a = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
      fadePanel.color = panelColor;

      yield return null;
    }
  }
}
