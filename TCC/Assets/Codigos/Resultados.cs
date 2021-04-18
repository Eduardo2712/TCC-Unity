using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class Resultados : MonoBehaviour
{
    public TMP_Text tempo, taxaAcerto, tempoSinalizacoes, total, direita, esquerda, cima, baixo;
    public GameObject painelResultados;

    private void Awake()
    {
        StartCoroutine(LoadDevice("nome"));
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        tempo.text = Informacoes.tempo + " seg.";
        direita.text = "Direita: " + Informacoes.acertoDireita + "/" + Informacoes.direita;
        esquerda.text = "Esquerda: " + Informacoes.acertoEsquerda + "/" + Informacoes.esquerda;
        cima.text = "Cima: " + Informacoes.acertoCima + "/" + Informacoes.cima;
        baixo.text = "Baixo: " + Informacoes.acertoBaixo + "/" + Informacoes.baixo;
        taxaAcerto.text = "" + (float.Parse(Informacoes.acertos) / float.Parse(Informacoes.total) * 100).ToString("F2") + "%";
        tempoSinalizacoes.text = Informacoes.tempoSetasMin + " - " + Informacoes.tempoSetasMax;
        total.text = Informacoes.total;
        if (Informacoes.vertical == true || Informacoes.horizontal == true)
        {
            painelResultados.SetActive(true);
        }
        else
        {
            painelResultados.SetActive(false);
        }
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }

    public void Fechar()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Sair()
    {
        Application.Quit();
    }
}