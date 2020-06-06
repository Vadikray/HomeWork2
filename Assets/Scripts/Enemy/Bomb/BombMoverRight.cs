using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMoverRight : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
