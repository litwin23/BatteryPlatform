using UnityEngine;

public class PlatformNOTInvisible : MonoBehaviour
{
    private Transform player; // было public, стало private

    [System.Serializable]
    public class SpawnObject
    {
        public GameObject prefab;
        public float chance;
    }

    public SpawnObject[] objects;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // находит сам
    }

    void Update()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        foreach (GameObject obj in platforms)
        {
            if (obj.transform.position.y < player.position.y - 5f)
            {
                Destroy(obj);
            }
        }
    }
}