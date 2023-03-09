using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;

    [SerializeField]
    private float _tiempoDeAutodestruccion = 3;

    private GUIManager _gui;
    
    void Start() 
    {
        Destroy(gameObject, _tiempoDeAutodestruccion);

        GameObject guiGO = GameObject.Find("GUIManager");
        Assert.IsNotNull(guiGO, "no hay GUIManager");

        _gui = guiGO.GetComponent<GUIManager>();
        Assert.IsNotNull(_gui, "GUIManager no tiene componente");
    }

    void Update()
    {
        transform.Translate(
            0,
            _speed * Time.deltaTime,
            0
        );
    }
 
    void OnCollisionEnter(Collision c) 
    {
        print("ENTER " + c.transform.name);
    }

    void OnCollisionStay(Collision c) 
    {
        print("STAY");
    }

    void OnCollisionExit(Collision c) 
    {
        print("EXIT");
    }

    void OnTriggerEnter(Collider c)
    {
        print("TRIGGER ENTER");
        _gui._texto.text = "ENTRE " + transform.name;
        Enemy enemy = c.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.Die();
        }
        Destroy(gameObject, 0.1f);
    }

    void OnTriggerStay(Collider c)
    {
        print("TRIGGER STAY");
    }

    void OnTriggerExit(Collider c)
    {
        print("TRIGGER EXIT");
        _gui._texto.text = "SALI " + transform.name;
    }
}
