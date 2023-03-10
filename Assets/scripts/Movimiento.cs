using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Transform))]
public class Movimiento : MonoBehaviour
{   
    public GameObject Enemy;

    public float TiempoEnemy;

    public float NuevoEnemy;
    private Transform _transform;

    [SerializeField]
    private float minY, maxY, minX, maxX;

    [SerializeField]
    private float _speed = 10;

    [SerializeField]
    private Proyectil _disparoOriginal;

    [SerializeField]
    private float _tiempoEntreDisparos = 0.5f;

    private float _tiempoUltimoDisparo = -Mathf.Infinity;

    private GUIManager _gui;

    private Score scoreSystem;

    void Awake()
    {}

    void Start()
    {
        _transform = GetComponent<Transform>();

        Assert.IsNotNull(_disparoOriginal, "DISPARO NO PUEDE SER NULO");
        Assert.IsNotNull(Enemy, "ENEMIGO NO PUEDE SER NULO");
        GameObject guiGO = GameObject.Find("GUIManager");
        Assert.IsNotNull(guiGO, "no hay GUIManager");

        _gui = guiGO.GetComponent<GUIManager>();
        Assert.IsNotNull(_gui, "GUIManager no tiene componente");

        GameObject score = GameObject.Find("Score");
        Assert.IsNotNull(score, "no se encontrĂ³ el Score");

        scoreSystem = score.GetComponent<Score>();
        Assert.IsNotNull(scoreSystem, "ScoreManager no tiene componente");
    }

    void moveShip()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (transform.position.y > maxY && vertical > 0) {
            vertical = 0;
        } 
        else if (transform.position.y < minY && vertical < 0) {
            vertical = 0;
        }

        if (transform.position.x > maxX && horizontal > 0) {
            horizontal = 0;
        }
        else if (transform.position.x < minX && horizontal < 0) {
            horizontal = 0;
        }

        transform.Translate(
            horizontal * _speed * Time.deltaTime, 
            vertical * _speed * Time.deltaTime, 
            0, 
            Space.World
        );
    }

    void shoot()
    {
        _tiempoUltimoDisparo = Time.time;

        // Instancia un nuevo proyectil y agrega los componentes necesarios para que detecte colisiones
        Proyectil nuevoProyectil = Instantiate(
            _disparoOriginal,
            transform.position,
            _disparoOriginal.transform.rotation);
        nuevoProyectil.gameObject.AddComponent<Rigidbody>();
        nuevoProyectil.gameObject.AddComponent<Proyectil>();
    }

    void Update()
    {
        moveShip();

        if (Input.GetKeyDown("e")) 
        {
            int random = UnityEngine.Random.Range(-5, 5);
            GameObject enemy = Instantiate(Enemy, new Vector3(random, 5, 0), Quaternion.identity);
            Destroy(enemy, 5);
        }

        if (Input.GetButtonDown("Jump") && Time.time >= _tiempoUltimoDisparo + _tiempoEntreDisparos) 
        {
            shoot();
        }

        _gui._texto.text = "Score: " + scoreSystem.GetScore() + "\n" + "Health: " + scoreSystem.GetHealth();

        if (scoreSystem.GetHealth() <= 0) {
            _gui._texto.text = "GAME OVER";
            Destroy(gameObject);
        }
        else if (scoreSystem.GetScore() >= 20) {
            _gui._texto.text = "YOU WIN";
            Destroy(gameObject);
        }
    }
}
