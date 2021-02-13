using UnityEngine;

public class AsteroidSpawnController
{
    private float _randomCoordinateInX;
    private float _randomCoordinateInY;

    private float _spawnTime = 150.0f;

    private static GameObject _playerPosition;

    public void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    public void UpdateExecute()
    {
        _spawnTime -= 0.5f;

        if (_spawnTime == 0.0f)
        {
            var spawnPosition = _playerPosition.transform.position + GetCoordinates();
            var staticAsteroid = ObjectPool.GetObjectFromPool("Static Asteroid");
            if (staticAsteroid != null)
            {
                staticAsteroid.transform.position = spawnPosition;
                staticAsteroid.transform.rotation = Quaternion.identity;
                staticAsteroid.GetComponent<AsteroidView>().OnAsteroidIsHitByBullet += DestroyAsteroid;
                staticAsteroid.GetComponent<AsteroidView>().OnAsteroidDestroyed += PlayerController.ApplyScore;
                staticAsteroid.SetActive(true);
            }

            _spawnTime = 150.0f;
        }
    }
    
    private Vector3 GetCoordinates()
    {
        var position = _playerPosition.transform.position;
        _randomCoordinateInX = Random.Range(-7000.0f, 7000.0f);
        _randomCoordinateInY = Random.Range(8000.0f, 12000.0f);
        return new Vector3(_randomCoordinateInX, _randomCoordinateInY, 0.0f);
    }

    private static void DestroyAsteroid(GameObject asteroid)
    {
        asteroid.SetActive(false);
        asteroid.GetComponent<AsteroidView>().OnAsteroidIsHitByBullet -= DestroyAsteroid;
        asteroid.GetComponent<AsteroidView>().OnAsteroidDestroyed -= PlayerController.ApplyScore;
    }
}
