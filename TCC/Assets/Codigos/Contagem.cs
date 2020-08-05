using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Contagem : MonoBehaviour
{
    public TMP_Text texto;

    private float tempo;

    void Start()
    {
        Debug.Log(Informacoes.tempoIniciar);
    }

    void Update()
    {
        if (Informacoes.tempoIniciar < Time.timeSinceLevelLoad)
        {
            Informacoes.tempoIniciar = 0;
            SceneManager.LoadScene(Informacoes.nomeFase);
        }
        else
        {
            texto.SetText("" + (Informacoes.tempoIniciar - Time.timeSinceLevelLoad).ToString("F2"));
        }
    }
}
