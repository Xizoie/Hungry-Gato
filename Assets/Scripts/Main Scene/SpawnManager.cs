using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _foodPrefabs;  // Array for food prefabs
    private Vector3[] _spawnPositions1;                   // Array for 8 random spawn positions (first group)
    private Vector3[] _spawnPositions2;                   // Array for 3 random spawn positions (second group)

    // Variables for two specific spawn positions
    private int _pos1X, _pos1Z, _pos2X, _pos2Z;
    private int _index1, _index2;

    private void Awake()
    {
        // Initialize spawn positions for both groups (8 for the first group, 3 for the second group)
        _spawnPositions1 = new Vector3[13];  
        _spawnPositions2 = new Vector3[9];  
        SpawnInitialPositions();
        SpawnFoodItems();
    }

    private void SpawnInitialPositions()
    {
        // Generate 8 random positions for the first group (spawnPositions1)
        for (int i = 0; i < _spawnPositions1.Length; i++)
        {
            _spawnPositions1[i] = new Vector3(Random.Range(1, 8), 1, Random.Range(2, 12));
        }

        // Generate 3 random positions for the second group (spawnPositions2)
        for (int i = 0; i < _spawnPositions2.Length; i++)
        {
            _spawnPositions2[i] = new Vector3(Random.Range(1, 8), 1, Random.Range(2, 12));
        }

        // Randomize the spawn positions for the two specific spawn positions
        _pos1X = Random.Range(1, 8);
        _pos1Z = Random.Range(7, 12);
        _pos2X = Random.Range(7, 11);
        _pos2Z = Random.Range(2, 4);

        // Randomize the food prefab indexes for the first and second spawn
        _index1 = Random.Range(0, _foodPrefabs.Length);
        _index2 = Random.Range(0, _foodPrefabs.Length);
    }

    private void SpawnFoodItems()
    {
        // Spawn 8 food items at the first set of positions (spawnPositions1)
        for (int i = 0; i < _spawnPositions1.Length; i++)
        {
            Instantiate(_foodPrefabs[Random.Range(0, _foodPrefabs.Length)], _spawnPositions1[i], Quaternion.identity);
        }

        // Spawn 3 food items at the second set of positions (spawnPositions2)
        for (int i = 0; i < _spawnPositions2.Length; i++)
        {
            Instantiate(_foodPrefabs[Random.Range(0, _foodPrefabs.Length)], _spawnPositions2[i], Quaternion.identity);
        }

        // Spawn special food items at the first and second specific spawn positions
        Instantiate(_foodPrefabs[_index1], new Vector3(_pos1X, 1, _pos1Z), Quaternion.identity);  // First specific position
        Instantiate(_foodPrefabs[_index2], new Vector3(_pos2X, 1, _pos2Z), Quaternion.identity);  // Second specific position
    }
}