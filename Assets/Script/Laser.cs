using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 8f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*_speed* Time.deltaTime);
        DestroyLaser();
    }

    void DestroyLaser()
    {
        if(transform.position.y > 6.6f)
        {
            Destroy(this.gameObject);
        }
    }
}
