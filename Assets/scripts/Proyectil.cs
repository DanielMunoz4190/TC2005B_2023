using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    private float _tiempoDeAuotDestruccion = 3;

    void Start()
    {
        Destroy(gameObject, _tiempoDeAuotDestruccion);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            _speed * Time.deltaTime,
            0
        );
    }
}
