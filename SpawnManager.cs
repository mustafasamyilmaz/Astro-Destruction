using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _EnemyPrefab;
    [SerializeField]
    private GameObject _EnemyContainer;
    [SerializeField]
    private GameObject _TripleShotPrefab;
    [SerializeField]
    private GameObject _SpeedPrefab;
    [SerializeField]
    private GameObject _ShieldPrefab;
    [SerializeField]
    private bool _StopSpawning = false;
    
    
    // Start is called before the first frame update
    public void RoutineStarter()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnRoutine()
    {
        while (_StopSpawning == false)
        {
            yield return new WaitForSeconds(1.0f);
            Vector3 posToSpawn = new Vector3(Random.Range(-9.1f, 9.1f), 6.6f, 0);
            GameObject NewEnemy = Instantiate(_EnemyPrefab, posToSpawn, Quaternion.identity);
            NewEnemy.transform.parent = _EnemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        while(_StopSpawning == false)
        {
            int PowerUpDecider = Random.Range(0, 3);
            Vector3 posToSpawn2 = new Vector3(Random.Range(-9.1f, 9.1f), 6.6f, 0);
            switch (PowerUpDecider)
            {
                case 0: 
                    Instantiate(_TripleShotPrefab, posToSpawn2, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(_SpeedPrefab, posToSpawn2, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(_ShieldPrefab, posToSpawn2, Quaternion.identity);
                    break;

            }
            yield return new WaitForSeconds(Random.Range(2f,7f));
        }
    }

    public void OnPlayerDeath()
    {
        _StopSpawning = true;
    }
}
