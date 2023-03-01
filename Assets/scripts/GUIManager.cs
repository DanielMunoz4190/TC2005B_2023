using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public TMP_Text _texto;
    void Start()
    {
        Assert.IsNotNull(_texto, "Texto no puede ser nulo");

        _texto.text = "Hola desde el GUIManager";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
