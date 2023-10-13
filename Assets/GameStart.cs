using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
  void Start() {
    if(File.Exists("Saves.txt")) {
      var saves = File.ReadAllLines("Saves.txt");


      SceneManager.LoadScene(int.Parse(saves[0]));
    } else {
      File.Create("Saves.txt");

      File.WriteAllText("Saves.txt", "0\n0\n0");

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }
}
