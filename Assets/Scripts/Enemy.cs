using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemy;
    public GameObject explosion;
    public float moveSpeed = 15.0f;
    public bool changeDirection = false;
    void Start(){
        enemy = this.gameObject.GetComponent<Rigidbody2D> ();
    }

    void Update(){
        moveEnemy();
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
    }
}
