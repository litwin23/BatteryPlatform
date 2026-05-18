using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Префабы")]
    public GameObject[] platformPrefabs;

    [Header("Шансы (сумма = 100)")]
    public float[] spawnChances;

    [Header("Настройки спавна")]
    public float spawnOffsetY = 10f;
    public float minX = -3f;
    public float maxX = 3f;
    public float spawnCooldown = 1.5f;
    public float minDistanceBetween = 2f; // минимальная дистанция между платформами

    private Transform player;
    private float timer;
    private Vector3 lastSpawnPos; // запоминаем последнюю позицию

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastSpawnPos = player.position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnCooldown)
        {
            SpawnPlatform();
            timer = 0f;
        }
    }

    void SpawnPlatform()
    {
        float spawnY = Random.Range(player.position.y, player.position.y + spawnOffsetY); // рандом по Y
        float spawnX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 0f);

        float distance = Vector3.Distance(spawnPos, lastSpawnPos);
        if (distance < minDistanceBetween)
        {
            return;
        }

        GameObject prefab = GetRandomPrefab();

        if (prefab != null)
        {
            GameObject spawned = Instantiate(prefab, spawnPos, Quaternion.identity);
            spawned.tag = "SpawnedPlatform";
            lastSpawnPos = spawnPos;
        }
    }

    GameObject GetRandomPrefab()
    {
        float roll = Random.Range(0f, 100f);
        float cumulative = 0f;

        for (int i = 0; i < platformPrefabs.Length; i++)
        {
            cumulative += spawnChances[i];
            if (roll < cumulative)
                return platformPrefabs[i];
        }

        return platformPrefabs[0];
    }
}