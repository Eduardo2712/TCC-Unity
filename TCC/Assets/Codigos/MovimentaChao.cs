using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaChao : MonoBehaviour
{
    public List<GameObject> terrenos = new List<GameObject>();
    public Vector3 localProxChao;
    public float tempoDestruicao;
    public float tempoCriaNovoTerreno;
    public float tamanhoDosTerrenos_x;
    private int aleatorio;

    void Awake()
    {
        aleatorio = Random.Range(0, terrenos.Count);
        GameObject aux = Instantiate(terrenos[aleatorio], localProxChao, terrenos[aleatorio].transform.rotation);
        localProxChao.x += tamanhoDosTerrenos_x;
        Destroy(aux, tempoDestruicao);
        aleatorio = Random.Range(0, terrenos.Count);
        aux = Instantiate(terrenos[aleatorio], localProxChao, terrenos[aleatorio].transform.rotation);
        localProxChao.x += tamanhoDosTerrenos_x;
        Destroy(aux, tempoDestruicao);
        aleatorio = Random.Range(0, terrenos.Count);
        aux = Instantiate(terrenos[aleatorio], localProxChao, terrenos[aleatorio].transform.rotation);
        localProxChao.x += tamanhoDosTerrenos_x;
        Destroy(aux, tempoDestruicao);
    }

    void Start()
    {
        CriaChao();
        CriaChao();
        CriaChao();
        InvokeRepeating("CriaChao", 0f, tempoCriaNovoTerreno);
    }

    void Update()
    {

    }

    void CriaChao()
    {
        aleatorio = Random.Range(0, terrenos.Count);
        GameObject aux = Instantiate(terrenos[aleatorio], localProxChao, terrenos[aleatorio].transform.rotation);
        localProxChao.x += tamanhoDosTerrenos_x;
        Destroy(aux, tempoDestruicao);
    }
}
