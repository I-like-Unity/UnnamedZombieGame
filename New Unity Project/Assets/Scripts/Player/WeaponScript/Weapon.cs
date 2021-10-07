using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public GameObject model;

    public Vector3 placement;

    public bool rotateModel;

    public bool unlocked;

    public enum ShootingMode { Single, Burst, Automatic};
    public ShootingMode shootingMode;

    public float bulletsPerShot;

    public float shootingSpeed;

    public float damage;
    public float range;

    public float maxAmmo;
    public float reloadTime;

    public bool isReloading;

    public LayerMask layerMask;
}
