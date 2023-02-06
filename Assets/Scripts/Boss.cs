using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Boss : MonoBehaviour
{
    public bool active = false;
    public Rigidbody2D enemy;
    public GameObject explosion;
    public float moveSpeed = 15.0f;
    public bool changeDirection = false;
    public int lives;
    public GameObject gameOver;
    public GameObject winlose;
    private int startingLives;
    
    void Start(){
        enemy = this.gameObject.GetComponent<Rigidbody2D> ();
        startingLives = lives;
    }

    void Update(){
        if (active){
            moveEnemy();
        }
        else{
            lives = startingLives;
        }
        transform.rotation = Quaternion.identity;
    }

    public void moveEnemy() {
        if (changeDirection == true){
            enemy.velocity = new Vector2(1,0) * -1 * moveSpeed;
        }
        else {
            enemy.velocity = new Vector2 (1,0) * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "RightWall") {
            changeDirection = true;
        }
        if(col.gameObject.name == "LeftWall") {
            changeDirection = false;
        }
    }
    public void Explode(){
        Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        winlose.gameObject.GetComponent<TextMeshProUGUI>().text = "YOU WIN!";
        gameOver.gameObject.SetActive(true);
        LevelControl.playing = false;
    }

    public IEnumerator Shake(){
        for ( int i = 0; i < 2; i++){
            transform.localPosition += new Vector3(0.05f, 0.05f, 0);
            yield return new WaitForSeconds(0.05f);
            transform.localPosition -= new Vector3(0.05f, 0.05f, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
