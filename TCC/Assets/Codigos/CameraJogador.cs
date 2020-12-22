using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    public float velocidade;
    public int nVelocidade;
    public float horizontal, vertical;

    void Awake()
    {
        velocidade = Informacoes.velocidade;
        nVelocidade = Informacoes.nVelocidade;
    }

    private void VerificaVelocidade()
    {
        if (nVelocidade == 1)
        {
            velocidade = 0.5f;
        }
        if (nVelocidade == 2)
        {
            velocidade = 1;
        }
        if (nVelocidade == 3)
        {
            velocidade = 2;
        }
        if (nVelocidade == 4)
        {
            velocidade = 3;
        }
    }

    private void MudaVelocidade()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") > 0)
        {

        }
        if (Input.GetAxis("Vertical") < 0)
        {

        }
        if (Input.GetAxis("Horizontal") > 0)
        {

        }
        if (Input.GetAxis("Horizontal") < 0)
        {

        }
        if (Input.GetButtonDown("A"))
        {

        }
        if (Input.GetButtonDown("B"))
        {

        }
        if (Input.GetButtonDown("C") && nVelocidade < 4)
        {
            nVelocidade += 1;
        }
        if (Input.GetButtonDown("D") && nVelocidade > 1)
        {
            nVelocidade -= 1;
        }
        if (Input.GetButtonDown("OnOff"))
        {

        }
    }

    void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector3(velocidade, 0, 0);
    }

    void Update()
    {
        MudaVelocidade();
        VerificaVelocidade();
        transform.Translate (velocidade, 0, 0);
		//transform.Rotate (0, 0, 0);
        //transform.position = transform.position + velocidade * Time.deltaTime;
    }
}
