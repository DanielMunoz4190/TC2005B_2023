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
    // Colisiones
    // para checar que colisiones con fisica necesitamos:
    // 1. un collider
    // 2. un rigidbody
    // 3. un script que chequee las colisiones
    // el rigidbody es un componente que se agrega a un objeto y debe de estar en un objeto movil

    void onColissionEnter(Collision C){
        print("ENTER" + C.transform.name);

    }

    void onColissionStay(Collision C){
        print("STAY");

    }

    void onColissionExit(Collision C){
        print("EXIT");

    }

    void onTriggerEnter(Collider C){
        print("ENTER");

    }

    void onTriggerStay(Collider C){
        print("STAY");

    }

    void onTriggerExit(Collider C){
        print("EXIT");

    }
}

