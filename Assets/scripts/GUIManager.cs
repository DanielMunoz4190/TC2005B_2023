using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class GUIManager : MonoBehaviour
{
    [SerializeField]
    public TMP_Text _texto;

    void Start()
    {
        Assert.IsNotNull(_texto, "TEXTO NO PUEDE SER NULO");
        _texto.text = "Score: 0";
    }

    void Update()
    {}
}
