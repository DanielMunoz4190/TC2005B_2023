// usando .NET
// importamos namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// Debug.Log();
// Debug.LogWarning();

// Obligamos la presencia de un componente gameobject
[RequireComponent(typeof(Transform))]

public class Movimiento : MonoBehaviour
{
    // Aceder a otro componente
    private Transform transform;

    [SerializeField]

    private float _speed = 10;
    
    // Ciclo de vida  - metodos que se invocan durante el script

    // se invoca una vez al inicio de la vida del componente
    // awake se invoca aunque el objeto este deshabilitado
    void Awake()
    {
    }

    // Se invoca una vez que se invocaron todos los awake
    void Start()
    {
        // Obtener referencia a otro componente
        // getcomponent es lento - se usa en start o awake
        // Puede regresar nulo
        transform = GetComponent<Transform>();
        Assert.IsNotNull(transform, "ES NECESARIO PARA MOVIMIENTO UN TRANFORM");
    }

    // Update is called once per frame
    // Minimo - 30 fps
    // Ideal - 60+ fps
    // Siempre vamos a tratar que sea lo mas simple posible
    // Se utiliza para la entrada de usuario y el movimiento
    void Update()
    {
        // polling por dispositivo:

        // True if: Estaba libre y ahora presionada
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("KEY DOWN: A");
        }

        // True if: Estaba presionada y ahora presionada
        if(Input.GetKey(KeyCode.Z))
        {
            Debug.Log("KEY: A");
        }

        // True if: Estaba presionada y ahora libre
        if(Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log("KEY UP: A");
        }

        // vamos a usar ejes:
        // Mapeo de hardware a un valor abstracto eje
        // rango [-1, 1]

        // Hacemos polling a eje
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        print(horizontal + " " + vertical);

        // se pueden usar ejes como botones
        if (Input.GetButtonDown("Jump"))
        {
            print("JUMP");
        }

        // como mover objetos
        // 1 directamente con su transform
        // 2 character controller
        // 3 motor de fisica
        // 4 navmesh (AI)

        transform.Translate(horizontal * _speed * Time.deltaTime, vertical * _speed * Time.deltaTime, 0, Space.World);

    }

    // Update que corre en intevalo fijado en la cnfiguracion del proyecto
    // No puede correr mas rapido que Update
    void FixedUpdate()
    {
    }

    // Corre todos los cuadros
    // Cada vez que los updates estan terminados
    void LateUpdate()
    {
    }
}
