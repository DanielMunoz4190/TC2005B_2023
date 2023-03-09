using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        // Destruye el enemigo cuando sea impactado por un proyectil
        Destroy(gameObject);
    }


}