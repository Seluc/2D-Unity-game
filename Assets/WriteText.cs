using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteText : MonoBehaviour {
  public string Text = "noText";
  public float DelayBetweenLettersAppear = 200f;
  public TextMeshPro TMP;

  private float timeElapsed = 0;
  private int stringCnt = 0;


  void Start() {}

  void Update() {
    if(stringCnt < Text.Length) {
      if(timeElapsed >= DelayBetweenLettersAppear) {
        TMP.text += Text[stringCnt];
        ++stringCnt;

        timeElapsed = 0;
      } else {
        timeElapsed += Time.deltaTime;
      }
    }
  }
}
