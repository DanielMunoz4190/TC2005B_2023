using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = -1;
    
    void Start() 
    {

    }

    void Update()
    {
        transform.Translate
        (
            0,
            _speed * Time.deltaTime,
            0
        );
    }

}