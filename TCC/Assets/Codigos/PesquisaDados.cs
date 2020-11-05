using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using UnityEngine.SceneManagement;
using TMPro;

public class PesquisaDados : MonoBehaviour
{
    public static PesquisaDados instancia;
    public SocketIOComponent socket;
    public GameObject content;
    public GameObject botaoDados;
    //public TMP_InputField textoNome;
    public DadosPacientes dadosPacientes = new DadosPacientes();
    //public int idClick = -1;
    //public string nome;
    //public int idade;

    void Start()
    {
        //textoNome.text = Informacoes.busca;
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

    public void OnReceivePong(SocketIOEvent pack)
    {
        dadosPacientes = JsonUtility.FromJson<DadosPacientes>(pack.data.ToString());
        int i = 0;
        while (i < dadosPacientes.dados.Length)
        {
            GameObject aux = Instantiate(botaoDados);
            aux.transform.SetParent(content.transform);
            //aux.GetComponent<BotaoPaciente>().idPaciente = pacientes.dados[i].idPaciente;
            //aux.GetComponent<BotaoPaciente>().nome = pacientes.dados[i].nome.ToString();
            if (dadosPacientes.dados[i].nome.Length > 25)
            {
                aux.transform.GetChild(0).GetComponent<Text>().text = dadosPacientes.dados[i].nome.Substring(0, 25);
            }
            else
            {
                aux.transform.GetChild(0).GetComponent<Text>().text = dadosPacientes.dados[i].nome;
            }
            aux.transform.GetChild(1).GetComponent<Text>().text = dadosPacientes.dados[i].horaData;
            aux.transform.GetChild(2).GetComponent<Text>().text = dadosPacientes.dados[i].tempo.ToString();
            aux.transform.GetChild(3).GetComponent<Text>().text = dadosPacientes.dados[i].porcentagemAcerto.ToString() + "%";
            //aux.GetComponent<BotaoPaciente>().idade = pacientes.dados[i].idade;
            //aux.GetComponent<BotaoPaciente>().envio = this;
            aux.transform.localScale = new Vector3(1, 1, 1);
            i++;
        }
    }

    public void BuscaDados()
    {
        Dictionary<string, string> pack = new Dictionary<string, string>();
        pack["mensagem"] = "BUSCAEXERCICIO";
        //pack["nome"] = Informacoes.busca;
        socket.Emit("PING", new JSONObject(pack));
    }

    public void Selecionar()
    {
        /*if (idClick > -1)
        {
            Informacoes.id = idClick.ToString();
            Informacoes.nome = nome;
            Informacoes.idade = idade.ToString();
            SceneManager.LoadScene("Inicio");
        }*/
    }

    public void Voltar()
    {
        Informacoes.busca = "";
        SceneManager.LoadScene("PrimeiraTela");
    }

    void Update()
    {

    }

    IEnumerator TempoEspera()
    {
        yield return new WaitForSeconds(1f);
        BuscaDados();
    }
}
