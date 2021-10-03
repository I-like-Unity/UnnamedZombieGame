using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();

    public List<GameObject> unlockedWeapons = new List<GameObject>();

    private int curWeaponIndex;

    [SerializeField] private Transform weaponTransform;

    void Start()
    {
        foreach (Weapon w in weapons)
        {
            if (w.unlocked)
            {
                GameObject curObj = Instantiate(w.model, weaponTransform.position, Quaternion.identity, weaponTransform);

                unlockedWeapons.Add(curObj);

                curObj.AddComponent<WeaponScript>();
                curObj.GetComponent<WeaponScript>().weapon = w;
            }
        }
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        float scroolWheel = Input.GetAxisRaw("Mouse ScroolWheel");

        curWeaponIndex += (int)scroolWheel;

        if (curWeaponIndex > unlockedWeapons.Count - 1)
        {
            curWeaponIndex = 0;
        }
        else if (curWeaponIndex < 0)
        {
            curWeaponIndex = unlockedWeapons.Count - 1;
        }

        unlockedWeapons[curWeaponIndex].SetActive(true);

        foreach (GameObject g in unlockedWeapons) g.SetActive(false);
    }
}
