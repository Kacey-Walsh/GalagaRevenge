using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour {
    public float moveSpeed = 10.0f;
    public GameObject explosion;
    public GameObject gameOver;
    public GameObject winlose;
    public Rigidbody2D player;
    void Start () {
        player = this.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate () {
        if (LevelControl.playing){
            MovePlayer();
        }
    }
    public void MovePlayer(){
        player.velocity = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) * moveSpeed;
    }
    public void Explode(){

        gameOver.gameObject.SetActive(true);
        winlose.GetComponent<TextMeshProUGUI>().text = "YOU DIED";
        Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }
}