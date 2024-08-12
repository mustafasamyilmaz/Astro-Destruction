using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    public GameObject _laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -3, 0);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
    }
}
