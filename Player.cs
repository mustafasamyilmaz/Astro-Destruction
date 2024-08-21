using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7f;

    [SerializeField]
    public GameObject _laserPrefab;

    [SerializeField]
    private GameObject _TripleShot;

    private float _canFire = -1f;
    private float _fireRate = 0.4f;

    [SerializeField]
    private float _lives = 3;

    [SerializeField]
    private SpawnManager _spawnManager;

    [SerializeField]
    private bool _isTripleShotActive = false;

    [SerializeField]
    private bool _isShieldsActive = false;

    [SerializeField]
    private GameObject _shieldVis;

    // Start is called before the first frame update
    void Start()
    {
        if(_spawnManager == null)
        {
            Debug.LogError("Spawnmanager is null");
        }

        else
        {
            _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            transform.position = new Vector3(0, -3, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        ShootLaser();
    }
    void CalculateMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.1f, 9.1f),transform.position.y,0);
    }

    void ShootLaser()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            if (_isTripleShotActive)
            {
                Instantiate(_TripleShot, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.02f, 0), Quaternion.identity);
            }
        }
    }
    public void Damage()
    {
        if (_isShieldsActive)
        {
            _isShieldsActive = false;
            _shieldVis.SetActive(false);
            return;
        }
        _lives--;
        if(_lives < 1)
        { 
            Destroy(this.gameObject);
            _spawnManager.OnPlayerDeath();
        }
    }
    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(PowerUpRoutine());
       
    }

    public void SpeedPowerUp()
    {
        _speed = _speed * 2;
        StartCoroutine(PowerUpRoutine());
    }

    public void ShieldPowerUp()
    {
        _isShieldsActive = true;
        _shieldVis.SetActive(true);
    }

    IEnumerator PowerUpRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        if (_isTripleShotActive) 
        { 
            _isTripleShotActive = false; 
        }
        if (_speed != 7f)
        {
            _speed = 7f;
        }
        
    }
}
