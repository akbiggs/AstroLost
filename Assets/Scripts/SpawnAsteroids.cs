using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Mesh[] asteroidMeshes;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        decrementTimerBy(Time.deltaTime);
        if (isTimerExpired()) {
            spawnAsteroid();
            spawnAsteroid();
            restartTimer();
        }
    }

    private void decrementTimerBy(float delta) {
        this.timer -= delta;
    }

    private bool isTimerExpired() {
        return timer <= 0;
    }

    private void restartTimer() {
        timer = Random.Range(1,3);
    }

    private void spawnAsteroid() {
        GameObject asteroid = 
            Instantiate(
                asteroidPrefab,
                transform.position + new Vector3(Random.Range(-100, 100), Random.Range(-20f, 20f), 0),
                new Quaternion());
        
        asteroid.transform.localScale = new Vector3(2, 2, 2);
        
        int modelIndex = (int) Random.Range(0, asteroidMeshes.Length);
        Mesh chosenMesh = asteroidMeshes[modelIndex];
        asteroid.GetComponent<MeshFilter>().mesh = chosenMesh;
    }
}
