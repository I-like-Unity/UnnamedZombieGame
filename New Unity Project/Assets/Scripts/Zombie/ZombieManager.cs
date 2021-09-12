using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public List<GameObject> prefabs = new List<GameObject>();
    public List<GameObject> zombies = new List<GameObject>();

    [SerializeField] private float timeBetween;

    [SerializeField] private Vector3 spawnField;

    [SerializeField] private float maxSpawnHeight;

    [SerializeField] private float zombieHeight;

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        StartCoroutine(NewZombie());
    }

    IEnumerator NewZombie()
    {
        RaycastHit info;

        if (Physics.Raycast(new Vector3(Random.Range(0, spawnField.x), maxSpawnHeight, Random.Range(0, spawnField.z)), Vector3.down, out info))
        {
            GameObject curZombie = Instantiate(prefabs[0], info.point + Vector3.up * zombieHeight, Quaternion.identity, transform);

            zombies.Add(curZombie);

            curZombie.GetComponent<Zombie>().playerPos = playerTransform;

            yield return new WaitForSeconds(timeBetween);
        }

        StartCoroutine(NewZombie());
    }
}
