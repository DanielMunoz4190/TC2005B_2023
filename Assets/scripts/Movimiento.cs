// estamos usando .NET
// Importamos las librerias que vamos a usar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
   //ciclo de vida de un objeto
    // existen medodos que se invocan en momentos especificos de la vida de un objeto
    // Start is called before the first frame update
    
    void awake(){
        Debug.Log("Estoy despierto");
    }
    void Start()
    {
        

        
    }
    // Update is called once per frame
    void Update(){

    }
    void FixedUpdate(){
        Debug.Log("Estoy en el fixed update");
    }
    void LateUpdate(){
        Debug.Log("Estoy en el late update");
    }

    
 
}
