using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Transform))]

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;

    [SerializeField]
    private Enemy _enemyOriginal;
   
    void Start()
    {
        _transform = GetComponent<Transform>();
        Assert.IsNotNull(_enemyOriginal, "ENEMY NO PUEDE SER NULO");
    }
    void enemy()
    {
        Instantiate(_enemyOriginal, _transform.position, transform.rotation);
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            enemy();
        }
        
    }
}
