using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrash : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;

    public GameObject[] trashPrefab;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SpawnTheTrash();
        }
    }

    public void SpawnTheTrash()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(trashPrefab[Random.Range(0,trashPrefab.Length)], pos, Quaternion.identity);
    }
}
