using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public static bool playing;
    public int score;
    public GameObject background;
    public GameObject boss;
    Color backgroundColor;

    void Start(){
        backgroundColor = background.GetComponent<SpriteRenderer>().material.color;
    }
    void Update()
    {
        if (score == 3){
            score++;
            StartCoroutine(NextLevel());
        }

        if(Input.GetKey(KeyCode.Escape)){
            Debug.Log("exit!");
            Application.Quit();
        }
    }
    private IEnumerator NextLevel()
    {
        while (backgroundColor.a > 0)
        {
            backgroundColor.a -= 0.01f;
            background.GetComponent<SpriteRenderer>().material.color = backgroundColor;
            yield return new WaitForSeconds(0.01f); // update interval
        }
        while (boss.transform.position.y > 2.5){
            float ypos = boss.transform.position.y;
            ypos -= 0.03f;
            boss.transform.position = new Vector3(boss.transform.position.x, ypos, boss.transform.position.z);
            yield return new WaitForSeconds(0.01f); // update interval
        }
        boss.GetComponent<Boss>().active = true;
    }
}
