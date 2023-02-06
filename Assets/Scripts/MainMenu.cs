using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
void Start(){
    if (LevelControl.playing == true){
        this.gameObject.SetActive(false);
    }
}
public void PlayGame ()
{
    LevelControl.playing = true;
    this.gameObject.SetActive(false);
}

public void QuitGame ()
{
    Debug.Log("exit!");

    Application.Quit();
}

}
