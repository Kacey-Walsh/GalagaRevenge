using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shoot : MonoBehaviour {
    public Transform projectileSpawn;
    public GameObject projectile;
    public float nextFire = 1.0f;
    public float currentTime = 0.0f;
    void Start (){
        projectileSpawn = this.gameObject.transform;
    }
    void Update (){
        if (LevelControl.playing){
            shoot ();
        }
    }
    public void shoot(){
        currentTime += Time.deltaTime;
        if (Input.GetButton ("Fire1") && currentTime > nextFire){
            nextFire += currentTime;
            GetComponent<AudioSource>().Play();
            Instantiate (projectile, projectileSpawn.position, Quaternion.identity);

            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }
}
