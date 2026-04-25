using UnityEngine;

public class ScriptSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnObject
    {
        public GameObject prefab;
        public float chance;
    }

    public SpawnObject[] objects;
    
    void Update()
    {
        
    }
}
