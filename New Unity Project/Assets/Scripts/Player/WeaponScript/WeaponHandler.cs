using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();

    public List<GameObject> unlockedWeapons = new List<GameObject>();

    private int curWeaponIndex;

    [SerializeField] private Transform weaponTransform;

    private void Start()
    {
        UpdateWeapon();
    }

    void UpdateWeapon()
    {
        foreach (Weapon w in weapons)
        {
            print(w.unlocked);

            if (w.unlocked)
            {
                GameObject curObj = Instantiate(w.model, weaponTransform.position + w.placement, Quaternion.identity, weaponTransform);

                unlockedWeapons.Add(curObj);

                curObj.AddComponent<WeaponScript>();
                curObj.GetComponent<WeaponScript>().weapon = w;

                if (w.rotateModel) curObj.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
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
