using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPaciente : MonoBehaviour
{
    public string nome;
    public int idPaciente;
    public int idade;
    public Envio envio;

    public void Click()
    {
        envio.idClick = idPaciente;
    }
}
