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
        aleatorio = Random.Range(0, terrenos.Count - 1);
        GameObject aux = Instantiate(terrenos[aleatorio], localProxChao, terrenos[aleatorio].transform.rotation);
        localProxChao.x += tamanhoDosTerrenos_x;
        Destroy(aux, tempoDestruicao);
    }

    void Start()
    {
        localProxChao.x = 249;
        StartCoroutine(CriaChao());
    }

    void Update()
    {

    }

    IEnumerator CriaChao()
    {
        yield return new WaitForSeconds(tempoCriaNovoTerreno);
        aleatorio = Random.Range(0, terrenos.Count);
        GameObject aux = Instantiate(terrenos[aleatorio], localProxChao, terrenos[aleatorio].transform.rotation);
        localProxChao.x += tamanhoDosTerrenos_x;
        Destroy(aux, tempoDestruicao);
        StartCoroutine(CriaChao());
    }
}
