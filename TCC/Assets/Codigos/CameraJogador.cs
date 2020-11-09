using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(velocidade, 0, 0);
    }
}
