using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public TMP_InputField tempo, tempoSetasMin, tempoSetasMax, nome, idade;
    public Toggle informacoesTela, vertical, horizontal;
    public GameObject painelAviso, painelTempos;

    private bool carregarCenario = false;

    public void HandleInputData(int val)
    {
        if(val == 0)
        {
            Informacoes.tempoIniciar = 0f;
        }
        else if (val == 1)
        {
            Informacoes.tempoIniciar = 15f;
        }
        else if (val == 2)
        {
            Informacoes.tempoIniciar = 30f;
        }
        else if (val == 3)
        {
            Informacoes.tempoIniciar = 60f;
        }
        else if (val == 4)
        {
            Informacoes.tempoIniciar = 90f;
        }
    }

    private void PassaInformacoes()
    {
        Informacoes.tempo = tempo.text;
        Informacoes.vertical = vertical.isOn;
        Informacoes.horizontal = horizontal.isOn;
        Informacoes.informacoesTela = informacoesTela.isOn;
        Informacoes.tempoSetasMax = tempoSetasMax.text;
        Informacoes.tempoSetasMin = tempoSetasMin.text;
        Informacoes.nome = nome.text;
        Informacoes.idade = idade.text;
    }

    public void Fechar()
    {
        Application.Quit();
    }

    private void MensagemAtencao()
    {
        if (tempo.text != "" && tempoSetasMax.text != "" && tempoSetasMin.text != "" && Informacoes.tempoIniciar > 0)
        {
            if ((int.Parse(tempo.text) >= 20 && vertical.isOn == false && horizontal.isOn == false) || (int.Parse(tempo.text) >= 20 && int.Parse(tempoSetasMin.text) >= 5 && int.Parse(tempoSetasMax.text) >= 5 && vertical.isOn == true && horizontal.isOn == true) || (int.Parse(tempo.text) >= 20 && int.Parse(tempoSetasMin.text) >= 5 && int.Parse(tempoSetasMax.text) >= 5 && vertical.isOn == false && horizontal.isOn == true) || (int.Parse(tempo.text) >= 20 && int.Parse(tempoSetasMin.text) >= 5 && int.Parse(tempoSetasMax.text) >= 5 && vertical.isOn == true && horizontal.isOn == false))
            {
                carregarCenario = true;
            }
            else
            {
                carregarCenario = false;
                painelAviso.SetActive(true);
            }
        }
        else
        {
            carregarCenario = false;
            painelAviso.SetActive(true);
        }
    }

    public void BotaoFloresta()
    {
        MensagemAtencao();
        if (carregarCenario == true)
        {
            PassaInformacoes();
            Informacoes.nomeFase = "Floresta";
            SceneManager.LoadScene("Espera");
        }
    }

    public void BotaoCidadeChuva()
    {
        MensagemAtencao();
        if (carregarCenario == true)
        {
            PassaInformacoes();
            Informacoes.nomeFase = "CidadeChuva";
            SceneManager.LoadScene("Espera");
        }
    }

    public void FecharPainelAviso()
    {
        painelAviso.SetActive(false);
    }

    private void Awake()
    {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        painelTempos.SetActive(false);
        painelAviso.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (vertical.isOn == true || horizontal.isOn == true)
        {
            painelTempos.SetActive(true);
        }
        else
        {
            painelTempos.SetActive(false);
            tempoSetasMax.text = "0";
            tempoSetasMin.text = "0";
        }
    }
}