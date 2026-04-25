using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
   public Transform player;
   
   [System.Serializable]
   public class SpawnObject
   {
      public GameObject prefab;
      public float chance;
   }

   public SpawnObject[] objects;
   
   void Update()
   {
      GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

      foreach (GameObject obj in platforms)
      {
         if (obj.transform.position.y < player.position.y - 20f)
         {
            Destroy(obj);
         }
      }
   }
}
