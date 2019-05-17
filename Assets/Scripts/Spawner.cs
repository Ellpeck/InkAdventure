using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {

    public float distanceFromCenter;
    public float spawnInterval;
    public GameObject[] spawnedObjects;

    private float spawnTimer;

    private void Start() {
        this.spawnTimer = this.spawnInterval;
    }

    private void Update() {
        this.spawnTimer += Time.deltaTime;
        while (this.spawnTimer >= this.spawnInterval) {
            this.spawnTimer -= this.spawnInterval;

            var pos = (Vector2) this.transform.position + Random.insideUnitCircle.normalized * this.distanceFromCenter;
            var obj = this.spawnedObjects[Random.Range(0, this.spawnedObjects.Length)];
            Instantiate(obj, pos, Quaternion.identity);
        }
    }

}