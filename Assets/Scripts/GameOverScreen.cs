using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

public void RestartButton() {
    LevelControl.playing = true;
    SceneManager.LoadScene("Galaga");
}

public void ExitButton() {
    LevelControl.playing = false;
    SceneManager.LoadScene("Galaga");
}

}
