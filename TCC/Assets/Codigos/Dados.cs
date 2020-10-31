using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dados
{
    public int idPaciente;
    public string nome;
    public int idade;
    public int ativo;
}

[System.Serializable]
public class Pacientes
{
    public Dados[] dados;
}