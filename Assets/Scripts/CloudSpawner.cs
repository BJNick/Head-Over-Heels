using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float verticalRange = 5f;
    public float horizontalOffset = 20f;
    
    public float spawnInterval = 3f;
    
    private float posSinceLastSpawn = 0f;
    private float spawnZ = -2f;
    
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.x - posSinceLastSpawn >= spawnInterval)
        {
            SpawnCloud();
            posSinceLastSpawn = Camera.main.transform.position.x;
        }
        
        if (Input.GetKeyDown(KeyCode.R)) {
            posSinceLastSpawn = Camera.main.transform.position.x;
        }
    }
    
    private void SpawnCloud()
    {
        float randomY = Random.Range(-verticalRange, verticalRange);
        Vector3 spawnPosition = new Vector3(Camera.main.transform.position.x + horizontalOffset, randomY, spawnZ);
        float randomScale = Random.Range(minScale, maxScale);
        var obj = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
        obj.transform.localScale = new Vector3(randomScale, randomScale, 1f);
    }
}
