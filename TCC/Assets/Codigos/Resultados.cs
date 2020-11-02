using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using SocketIO;

public class Resultados : MonoBehaviour
{
    public TMP_Text tempo, taxaAcerto, tempoSinalizacoes, total, direita, esquerda, cima, baixo;
    public GameObject painelResultados;
    public static Resultados instancia;
    public SocketIOComponent socket;

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

    IEnumerator TempoEspera()
    {
        yield return new WaitForSeconds(0.1f);
        SendPingToServer();
    }

    public void Fechar()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void OnReceivePong(SocketIOEvent pack)
    {

    }

    public void SendPingToServer()
    {
        Dictionary<string, string> pack = new Dictionary<string, string>();
        pack["mensagem"] = "EXERCICIO";
        pack["idPaciente"] = Informacoes.id;
        pack["tempo"] = Informacoes.tempo;
        pack["porcentagemAcerto"] = taxaAcerto.text;
        pack["cenario"] = Informacoes.nomeFase;
        socket.Emit("PING", new JSONObject(pack));
    }

    void Start()
    {
        if (instancia == null)
        {
            instancia = this;
            socket = GetComponent<SocketIOComponent>();
            socket.On("PONG", OnReceivePong);
        }
        else
        {
            Destroy(this.gameObject);
        }
        StartCoroutine("TempoEspera");
    }

    void Update()
    {

    }
}