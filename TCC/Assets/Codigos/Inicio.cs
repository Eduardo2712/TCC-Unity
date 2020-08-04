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

    private void PassaInformacoes()
    {
        Informacoes.tempo = tempo.text;
        Informacoes.vertical = vertical.isOn;
        Informacoes.horizontal = horizontal.isOn;
        Informacoes.informacoesTela = informacoesTela.isOn;
        Informacoes.tempoSetasMax = tempoSetasMax.text;
        Informacoes.tempoSetasMin = tempoSetasMin.text;
    }

    private void MensagemAtencao()
    {
        if (tempo.text != "" && tempoSetasMax.text != "" && tempoSetasMin.text != "")
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
            SceneManager.LoadScene("Floresta");
        }
    }

    public void BotaoCidadeChuva()
    {
        MensagemAtencao();
        if (carregarCenario == true)
        {
            PassaInformacoes();
            SceneManager.LoadScene("CidadeChuva");
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