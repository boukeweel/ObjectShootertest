using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public float speed;
    public float weight;

    [HideInInspector] public bool isShot;

    private Rigidbody rig;
     
    private void Start() {
        rig = GetComponent<Rigidbody>();
        if(speed <= 0) {
            speed = 3;
        }
        if(weight <= 0) {
            weight = 20;
        }
    }
    private void Update() {
        if (isShot) {
            Shot();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            isShot = false;
        }
    }
    public void Shot() {

    }
}
