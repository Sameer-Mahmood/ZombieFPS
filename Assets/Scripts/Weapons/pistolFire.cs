using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolFire : MonoBehaviour
{
    public GameObject Pistol;
    public bool isFiring = false;
    public GameObject muzzleFlash;
    public AudioSource pistolShot;
    public float toTarget;
    public GameObject Player;
    public float pDamage = 100f;
    
    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            if(isFiring == false) {
                StartCoroutine(FireThePistol());
            }
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit shot;
        if(Physics.Raycast(Player.transform.position, transform.TransformDirection(Vector3.forward), out shot, 100)) {
            Ghoul ghoul = shot.transform.GetComponent<Ghoul>();
            if(ghoul != null) {
                ghoul.zHit(pDamage);
                Debug.Log("Hit");
            }
            if(shot.collider.gameObject.tag == "Ghoul") {
                ghoul.GetComponent<Ghoul>().zHit(pDamage);
                Debug.Log("Hit");
            } 
        }
    }

    IEnumerator FireThePistol() {
        isFiring = true;
        toTarget = playerCasting.targetDistance;
        Pistol.GetComponent<Animator>().Play("FirePistol");
        muzzleFlash.SetActive(true);
        pistolShot.Play();
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.30f);
        Pistol.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }
}