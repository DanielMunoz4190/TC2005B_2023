using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyProyectil _disparoOriginal;

    [SerializeField]
    private float _tiempoEntreDisparos = 2;

        private Score scoreSystem;

    void Start() 
    {

                GameObject score = GameObject.Find("Score");
        Assert.IsNotNull(score, "no se encontró el Score");

        scoreSystem = score.GetComponent<Score>();
        Assert.IsNotNull(scoreSystem, "ScoreManager no tiene componente");
    }
       public void Die()
    {
        // Destruye el enemigo cuando sea impactado por un proyectil
        scoreSystem.AddScore();
        Destroy(gameObject);
    }
    void shoot()
    {
        // Instancia un nuevo proyectil y agrega los componentes necesarios para que detecte colisiones
        EnemyProyectil nuevoProyectil = Instantiate(
            _disparoOriginal,
            transform.position,
            _disparoOriginal.transform.rotation);
        nuevoProyectil.gameObject.AddComponent<Rigidbody>();
        nuevoProyectil.gameObject.AddComponent<EnemyProyectil>();
        
    }
    void Update()
    {
        // Dispara cada 2 segundos
        if (Time.time >=  _tiempoEntreDisparos) 
        {
            shoot();
           _tiempoEntreDisparos = Time.time + 2;
        }
    }


}