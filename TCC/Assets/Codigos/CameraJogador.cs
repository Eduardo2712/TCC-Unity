using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    public float velocidade;

    void Awake()
    {
        velocidade = Informacoes.velocidade;
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(velocidade, 0, 0);
    }
}
