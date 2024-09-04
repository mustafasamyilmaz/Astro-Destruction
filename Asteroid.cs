using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float _speed = -0.5f;
    private Animator _anim;
    private SpawnManager _spawnManager;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser") 
        {
            Destroy(this.gameObject, 1.5f);
            _anim.SetTrigger("OnAsteroidDestruction");
            _player.Sound(1);
            Destroy(other.gameObject);
            _spawnManager.RoutineStarter();

        }
    }

    
}
