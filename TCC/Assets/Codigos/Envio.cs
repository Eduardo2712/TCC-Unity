using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using UnityEngine.SceneManagement;
using TMPro;

public class Envio : MonoBehaviour
{
    public static Envio instancia;
    public SocketIOComponent socket;
    public GameObject content;
    public GameObject botao;
    public TMP_InputField textoNome;
    public Pacientes pacientes = new Pacientes();
    public int idClick = -1;
    public string nome;
    public int idade;

    void Start()
    {
        textoNome.text = Informacoes.busca;
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
        pacientes = JsonUtility.FromJson<Pacientes>(pack.data.ToString());
        int i = 0;
        while (i < pacientes.dados.Length)
        {
            GameObject aux = Instantiate(botao);
            aux.transform.SetParent(content.transform);
            aux.GetComponent<BotaoPaciente>().idPaciente = pacientes.dados[i].idPaciente;
            aux.GetComponent<BotaoPaciente>().nome = pacientes.dados[i].nome.ToString();
            if (pacientes.dados[i].nome.Length > 30)
            {
                aux.transform.GetChild(1).GetComponent<Text>().text = pacientes.dados[i].nome.Substring(0, 30);
            }
            else
            {
                aux.transform.GetChild(1).GetComponent<Text>().text = pacientes.dados[i].nome;
            }
            aux.transform.GetChild(0).GetComponent<Text>().text = pacientes.dados[i].idade.ToString();
            aux.GetComponent<BotaoPaciente>().idade = pacientes.dados[i].idade;
            aux.GetComponent<BotaoPaciente>().envio = this;
            aux.transform.localScale = new Vector3(1, 1, 1);
            i++;
        }
    }

    public void BuscaPaciente()
    {
        Dictionary<string, string> pack = new Dictionary<string, string>();
        pack["mensagem"] = "PESQUISA";
        pack["nome"] = Informacoes.busca;
        socket.Emit("PING", new JSONObject(pack));
    }

    public void Recarrega()
    {
        Informacoes.busca = textoNome.text.ToString();
        SceneManager.LoadScene("TelaPaciente");
    }

    public void Desativar()
    {
        Dictionary<string, string> pack = new Dictionary<string, string>();
        pack["mensagem"] = "EXCLUIR";
        pack["idPaciente"] = idClick.ToString();
        socket.Emit("PING", new JSONObject(pack));
        Informacoes.busca = "";
        SceneManager.LoadScene("TelaPaciente");
    }

    public void Cadastrar()
    {
        Informacoes.busca = "";
        SceneManager.LoadScene("Cadastro");
    }

    public void Selecionar()
    {
        if (idClick > -1)
        {
            Informacoes.id = idClick.ToString();
            Informacoes.nome = nome;
            Informacoes.idade = idade.ToString();
            SceneManager.LoadScene("Inicio");
        }
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
        BuscaPaciente();
    }
}
