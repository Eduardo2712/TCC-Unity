using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Conexao : MonoBehaviour
{
    public static Conexao instancia;
    public SocketIOComponent socket;

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
        Dictionary<string, string> result = pack.data.ToDictionary();
        Debug.Log("mensagem do servidor: " + result["message"]);
        //Debug.Log("ID: " + result["id"]);
    }

    public void SendPingToServer()
    {
        Dictionary<string, string> pack = new Dictionary<string, string>();
        pack["message"] = "A";
        socket.Emit("PING", new JSONObject(pack));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SendPingToServer();
        }
    }
}
