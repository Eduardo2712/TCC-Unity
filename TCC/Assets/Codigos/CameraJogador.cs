using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    public float velocidade;

    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(velocidade, 0, 0);
    }
}
