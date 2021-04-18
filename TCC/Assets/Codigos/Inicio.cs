using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public TMP_InputField tempo, tempoSetasMin, tempoSetasMax;
    public Toggle informacoesTela, vertical, horizontal;
    public GameObject painelAviso, painelTempos;

    private bool carregarCenario = false;

    public void TempoInicio(int val)
    {
        if (val == 0)
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

    public void Velocidade(int val)
    {
        if (val == 0)
        {
            Informacoes.velocidade = 0f;
            Informacoes.nVelocidade = 0;
        }
        else if (val == 1)
        {
            Informacoes.velocidade = 15;
            Informacoes.nVelocidade = 1;
        }
        else if (val == 2)
        {
            Informacoes.velocidade = 20;
            Informacoes.nVelocidade = 2;
        }
        else if (val == 3)
        {
            Informacoes.velocidade = 30;
            Informacoes.nVelocidade = 3;
        }
        else if (val == 4)
        {
            Informacoes.velocidade = 45;
            Informacoes.nVelocidade = 4;
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
            Debug.Log("ENTROU");
            painelAviso.SetActive(true);
        }
    }

    public void BotaoFloresta()
    {
        MensagemAtencao();
        if (carregarCenario == true)
        {
            PassaInformacoes();
            Informacoes.nomeFase = "FlorestaDia";
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

    public void BotaoFlorestaNoite()
    {
        MensagemAtencao();
        if (carregarCenario == true)
        {
            PassaInformacoes();
            Informacoes.nomeFase = "FlorestaNoite";
            SceneManager.LoadScene("Espera");
        }
    }

    public void FecharPainelAviso()
    {
        painelAviso.SetActive(false);
    }

    private void Awake()
    {
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
            tempoSetasMax.text = "5";
            tempoSetasMin.text = "5";
        }
    }
}