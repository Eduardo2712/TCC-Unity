using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;
using UnityEngine.SceneManagement;
using TMPro;

public class Cadastrar : MonoBehaviour
{
    public static Cadastrar instancia;
    public SocketIOComponent socket;
    public TMP_InputField textoNome, textoIdade;

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
    }

    public void OnReceivePong(SocketIOEvent pack)
    {
        
    }

    public void SendPingToServer()
    {
        Dictionary<string, string> pack = new Dictionary<string, string>();
        pack["mensagem"] = "CADASTRAR";
        pack["nome"] = textoNome.text;
        pack["idade"] = textoIdade.text;
        socket.Emit("PING", new JSONObject(pack));
    }

    public void Cadastro()
    {
        
    }

    void Update()
    {

    }
}
