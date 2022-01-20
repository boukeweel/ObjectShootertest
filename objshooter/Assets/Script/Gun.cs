using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float PressButton;
    public float HandPress;

    private RumbleGun rumbleGun;

    public GameObject Bullet;

    private float shootRumble;

    private void Start() {
        rumbleGun = GetComponent<RumbleGun>();
    }
    private void FixedUpdate() {

        PressButton = Mathf.Max(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger));
        if (PressButton > 0.5f) {
            Debug.Log("werkt");
            if (Bullet != null) {
                Shoot();
            }
        }else if (PressButton <= 0) {
            shootRumble = 0.5f;
        }
        HandPress = Mathf.Max(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger));
        if(HandPress > 0.5f) {
            RayCast();
        }
    }

    private void RayCast() {
        int layermask = LayerMask.GetMask("Shootebol");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, layermask)) {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            SuckObject(hit.transform.gameObject);
        }

    }

    private void SuckObject(GameObject _gameObject) {
        if(_gameObject.GetComponent<Projectil>().isShot == false) {
            Bullet = gameObject;
        }
    }

    private void Shoot() {

        GameObject NewProjectile = Instantiate(Bullet) as GameObject;
        NewProjectile.transform.position = transform.position;
        Projectil pro = NewProjectile.GetComponent<Projectil>();
        Rigidbody rb = NewProjectile.GetComponent<Rigidbody>();
        rb.velocity = gameObject.transform.forward * pro.speed;
        

        shootRumble -= Time.deltaTime;
        if (shootRumble > 0) {
            rumbleGun.RumbleController();
        }

        Bullet = null;
    }
}
