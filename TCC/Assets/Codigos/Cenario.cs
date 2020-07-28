using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class Cenario : MonoBehaviour
{
    public Image direita, esquerda, cima, baixo;
    public TextMeshProUGUI textoTempo, textoTaxaAcerto, textoDirecoes;

    private int seta1 = -1, seta2 = -1;
    private double tempo = 5;
    private bool acertou = false;
    private double total = 0, acertos = 0;
    private int pontosDireita = 0, pontosEsquerda = 0, pontosCima = 0, pontosBaixo = 0, direitaAcerto, esquerdaAcerto, cimaAcerto, baixoAcerto;
    private int seta = -1;

    private void AtivaSetas(Vector3 vetor)
    {
        if (tempo < Time.timeSinceLevelLoad)
        {
            acertou = false;
            tempo = Time.timeSinceLevelLoad + Random.Range(int.Parse(Informacoes.tempoSetasMin), int.Parse(Informacoes.tempoSetasMax));
            seta = Random.Range(seta1, seta2);
            if (seta == 0)
            {
                pontosEsquerda += 1;
                StartCoroutine(AtivaDireita());
            }
            else if (seta == 1)
            {
                pontosDireita += 1;
                StartCoroutine(AtivaEsquerda());
            }
            else if (seta == 2)
            {
                pontosCima += 1;
                StartCoroutine(AtivaCima());
            }
            else if (seta == 3)
            {
                pontosBaixo += 1;
                StartCoroutine(AtivaBaixo());
            }
        }
        if (direita.enabled == true && vetor.x >= 0.1)
        {
            direita.enabled = false;
            acertos += 1;
            direitaAcerto += 1;
            total += 1;
            acertou = true;
        }
        if (esquerda.enabled == true && vetor.x <= -0.1)
        {
            esquerda.enabled = false;
            acertos += 1;
            esquerdaAcerto += 1;
            total += 1;
            acertou = true;
        }
        if (cima.enabled == true && vetor.z >= 0.5)
        {
            cima.enabled = false;
            acertos += 1;
            cimaAcerto += 1;
            total += 1;
            acertou = true;
        }
        if (baixo.enabled == true && vetor.z <= -0.5)
        {
            baixo.enabled = false;
            acertos += 1;
            baixoAcerto += 1;
            total += 1;
            acertou = true;
        }
    }

    private IEnumerator AtivaDireita()
    {
        direita.enabled = true;
        yield return new WaitForSeconds(3);
        direita.enabled = false;
        if (acertou == false)
        {
            total += 1;
        }
    }

    private IEnumerator AtivaEsquerda()
    {
        esquerda.enabled = true;
        yield return new WaitForSeconds(3);
        esquerda.enabled = false;
        if (acertou == false)
        {
            total += 1;
        }
    }

    private IEnumerator AtivaCima()
    {
        cima.enabled = true;
        yield return new WaitForSeconds(3);
        cima.enabled = false;
        if (acertou == false)
        {
            total += 1;
        }
    }

    private IEnumerator AtivaBaixo()
    {
        baixo.enabled = true;
        yield return new WaitForSeconds(3);
        baixo.enabled = false;
        if (acertou == false)
        {
            total += 1;
        }
    }

    private void AtualizaTextos()
    {
        if (Informacoes.informacoesTela == true)
        {
            textoTempo.text = "Tempo: " + Time.timeSinceLevelLoad.ToString("F2");
            if (Informacoes.horizontal == true && Informacoes.vertical == true)
            {
                textoDirecoes.text = "C: " + pontosCima + " B: " + pontosBaixo + " D: " + pontosDireita + " E: " + pontosEsquerda;
            }
            else if (Informacoes.horizontal == true)
            {
                textoDirecoes.text = "D: " + pontosDireita + " E: " + pontosEsquerda;
            }
            else if (Informacoes.vertical == true)
            {
                textoDirecoes.text = "C: " + pontosCima + " B: " + pontosBaixo;
            }
            if (total > 0)
            {
                textoTaxaAcerto.text = "Taxa de acerto: " + ((acertos / total) * 100).ToString("F2") + "%";
            }
            else
            {
                textoTaxaAcerto.text = "Taxa de acerto: 0%";
            }
        }
        else
        {
            textoTempo.text = "";
            textoDirecoes.text = "";
            textoTempo.text = "";
            textoTaxaAcerto.text = "";
        }
    }

    private void VerificaValores()
    {
        if (Informacoes.horizontal == true && Informacoes.vertical == true)
        {
            seta1 = 0;
            seta2 = 4;
        }
        else if (Informacoes.horizontal == true)
        {
            seta1 = 0;
            seta2 = 2;
        }
        else if (Informacoes.vertical == true)
        {
            seta1 = 2;
            seta2 = 4;
        }
    }

    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = true;
    }

    private void Awake()
    {
        StartCoroutine(LoadDevice("cardboard"));
        VerificaValores();
    }

    // Start is called before the first frame update
    void Start()
    {
        direita.enabled = false;
        esquerda.enabled = false;
        cima.enabled = false;
        baixo.enabled = false;
        pontosDireita = 0;
        pontosEsquerda = 0;
        pontosCima = 0;
        pontosBaixo = 0;
        direitaAcerto = 0;
        esquerdaAcerto = 0;
        cimaAcerto = 0;
        baixoAcerto = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (double.Parse(Informacoes.tempo) >= Time.timeSinceLevelLoad)
        {
            Vector3 vetor = Input.acceleration;
            AtivaSetas(vetor);
            Debug.Log("Tempo setas: " + Informacoes.tempoSetasMin + " até " + Informacoes.tempoSetasMax + " Horizontal ? " + Informacoes.horizontal + " Vertical ? " + Informacoes.vertical);
            AtualizaTextos();
        }
        else
        {
            Informacoes.direita = "" + pontosDireita;
            Informacoes.esquerda = "" + pontosEsquerda;
            Informacoes.cima = "" + pontosCima;
            Informacoes.baixo = "" + pontosBaixo;
            Informacoes.acertos = "" + acertos;
            Informacoes.total = "" + total;
            Informacoes.acertoBaixo = "" + baixoAcerto;
            Informacoes.acertoCima = "" + cimaAcerto;
            Informacoes.acertoDireita = "" + direitaAcerto;
            Informacoes.acertoEsquerda = "" + esquerdaAcerto;
            SceneManager.LoadScene("Resultados");
        }
    }
}