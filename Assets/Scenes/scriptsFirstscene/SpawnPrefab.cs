using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    
    public GameObject prefabToSpawn;

   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
}
