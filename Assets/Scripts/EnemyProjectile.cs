using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Rigidbody2D projectile;

    public float moveSpeed = 15.0f;

    public GameObject levelControl;
    void Start()
    {
        levelControl = GameObject.Find("LevelControl");
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        projectile.velocity = new Vector2(0, -1) * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            levelControl.GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<Player>().Explode();
            col.gameObject.SetActive(false);
            Object.Destroy(this.gameObject);
        }
        if (col.gameObject.name == "BottomWall"){
            Object.Destroy(this.gameObject);
        }
    }
}
