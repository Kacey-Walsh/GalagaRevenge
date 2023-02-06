using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveProjectile : MonoBehaviour {
    public Rigidbody2D projectile;
    public float moveSpeed = 10.0f;
    public GameObject levelControl;
    void Start () {
        levelControl = GameObject.Find("LevelControl");
        projectile = this.gameObject.GetComponent<Rigidbody2D> ();
    }
    void Update () {
        projectile.velocity = new Vector2 (0,1) * moveSpeed;
    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Enemy" && col.gameObject.name != "Boss"){  
            levelControl.GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<ParticleSystem>().Play();
            levelControl.GetComponent<LevelControl>().score++;
            col.gameObject.GetComponent<Enemy>().Explode();
            col.gameObject.SetActive (false);
            Object.Destroy(this.gameObject);
        }
        if (col.gameObject.name == "Boss"){  
            levelControl.GetComponent<AudioSource>().Play();
            col.gameObject.GetComponent<Boss>().lives -= 1;
            if (col.gameObject.GetComponent<Boss>().lives <= 0){
                col.gameObject.GetComponent<Boss>().Explode();
                col.gameObject.SetActive (false);
            }
            else if (col.gameObject.GetComponent<Boss>().active){
                col.gameObject.GetComponent<Boss>().StartCoroutine(col.gameObject.GetComponent<Boss>().Shake());
            }
            Object.Destroy(this.gameObject);
        }
        if (col.gameObject.name == "TopWall"){
            Object.Destroy(this.gameObject);
        }
    }
}
