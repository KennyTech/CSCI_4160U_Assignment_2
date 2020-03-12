using UnityEngine;
using System.Collections;

public class FPS_Input : MonoBehaviour {
    [SerializeField] private Transform cam = null;
    [SerializeField] private GameObject bulletHolePrefab = null;
    //[SerializeField] private GameObject muzzleFlashPrefab = null;
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private AudioSource audioSource = null;
    [SerializeField] private GameObject ui = null;

    [SerializeField] private float range = 150f;

    void Update() {

        // Shoot (space, click)
        if (Input.GetButtonDown("Fire1") || (Input.GetButtonDown("Jump"))) {
            Shoot();
        }
    }

    private void Shoot() {
        RaycastHit hit;

        LayerMask enemyMask = LayerMask.GetMask("Enemies");
        LayerMask groundMask = LayerMask.GetMask("Ground");
        LayerMask buildingMask = LayerMask.GetMask("Building");

        audioSource.PlayDelayed(0.1f);

        if (Physics.Raycast(cam.position, cam.forward, out hit, range, enemyMask)) {
            Debug.Log("Shot an enemy:" + hit.collider.name);

            Health enemyHealth = hit.collider.GetComponent<Health>();
            enemyHealth.TakeDamage(10);
            ui.GetComponent<HitCount>().AddHitCount(1);

        } else if (Physics.Raycast(cam.position, cam.forward, out hit, range, groundMask)) {
            Debug.Log("Shot a wall:" + hit.collider.name);

            Instantiate(bulletHolePrefab, 
                hit.point + (0.01f * hit.normal), 
                Quaternion.LookRotation(-1 * hit.normal, hit.transform.up));
        } else if (Physics.Raycast(cam.position, cam.forward, out hit, range, buildingMask)) {
            Debug.Log("Shot a building:" + hit.collider.name);

            Instantiate(bulletHolePrefab, 
                hit.point + (0.01f * hit.normal), 
                Quaternion.LookRotation(-1 * hit.normal, hit.transform.up));
        }
    }
}
