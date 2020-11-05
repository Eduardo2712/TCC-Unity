using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DadosPesquisa
{
    public int idPaciente, idade, ativo;
    public int idExercicio;
    public string nome, cenario;
    public string horaData;
    public int tempo;
    public float porcentagemAcerto;
}

[System.Serializable]
public class DadosPacientes
{
    public DadosPesquisa[] dados;
}