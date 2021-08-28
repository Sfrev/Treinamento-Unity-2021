using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;
    [Tooltip("Time in seconds")] [SerializeField] private float spawnTime;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private bool spawn = false;
    [SerializeField] private float forceStrengh = 20f;
    private float timer = 0f;

    private SoundManager soundManager;

    private void Start()
    {
        soundManager = SoundManager.instance;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime && spawn)
        {
            timer = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject sphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

        soundManager.PlaySound("Laser");

        Vector3 force = new Vector3(Random.Range(-forceStrengh, forceStrengh), 
            Random.Range(-forceStrengh, forceStrengh), Random.Range(-forceStrengh, forceStrengh));

        sphere.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        Destroy(sphere, 5f);
    }
}
