using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private Player _player;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.LogError("player is null");
        }

        _animator = GetComponent<Animator>();

        if(_animator == null)
        {
            Debug.LogError("animator is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _player.Sound(1);
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 1.0f);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }
            _player.Sound(1);
            _animator.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject,1.0f);
        }

    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y < -5.7f)
        {
            transform.position = new Vector3(Random.Range(-9.1f, 9.1f),6.6f,0);
        }
    }
}
