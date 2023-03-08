using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Transform))]
public class Movimiento : MonoBehaviour
{
    private Transform _transform;

    [SerializeField]
    private float _speed = 10;

    [SerializeField]
    private Proyectil _disparoOriginal;

    [SerializeField]
    private float _tiempoEntreDisparos = 0.5f;

    private float _tiempoUltimoDisparo = -Mathf.Infinity;

    void Awake()
    {
        print("AWAKE");
    }

    void Start()
    {
        Debug.Log("START");

        _transform = GetComponent<Transform>();

        Assert.IsNotNull(_disparoOriginal, "DISPARO NO PUEDE SER NULO");
    }

    void moveShip()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(
            horizontal * _speed * Time.deltaTime, 
            vertical * _speed * Time.deltaTime, 
            0, 
            Space.World
        );
    }
    void shoot()
    {
        Instantiate(
            _disparoOriginal, 
            _transform.position,
            transform.rotation
        );
    }

    void Update()
    {
        moveShip();

        if (Input.GetButtonDown("Jump") && Time.time >= _tiempoUltimoDisparo + _tiempoEntreDisparos) 
        {
            _tiempoUltimoDisparo = Time.time;
            Instantiate(
            _disparoOriginal,
            transform.position,
            transform.rotation
            );
        }
    }
}
