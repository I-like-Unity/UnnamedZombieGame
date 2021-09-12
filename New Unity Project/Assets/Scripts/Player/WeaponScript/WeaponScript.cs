using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Weapon weapon;

    private Camera cam;

    private float ammo;

    private float timer = 0;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (ammo > weapon.maxAmmo) StartCoroutine(Reload());

        if (weapon.shootingMode < Weapon.ShootingMode.Automatic)
        {
            if (Input.GetMouseButtonDown(0) && timer > weapon.shootingSpeed)
            {
                timer = 0;
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButton(0) && timer > weapon.shootingSpeed)
            {
                timer = 0;
                Shoot();
            }
        }

        timer += Time.deltaTime;
    }

    void Shoot()
    {
        for (int i = 0; i < weapon.bulletsPerShot; i++)
        {
            RaycastHit info;

            if (Physics.Raycast(cam.transform.position, cam.transform.eulerAngles, out info, weapon.range, weapon.layerMask))
            {
                if (info.collider.gameObject.tag == "Target")
                {
                    //deal damage
                }
            }
        }
    }

    IEnumerator Reload()
    {
        weapon.isReloading = true;

        yield return new WaitForSeconds(weapon.reloadTime);

        ammo = weapon.maxAmmo;

        weapon.isReloading = false;
    }
}
