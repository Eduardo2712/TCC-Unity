using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaChao : MonoBehaviour
{
    public GameObject chao;
    private Vector3 localProxChao;

    // Start is called before the first frame update
    void Start()
    {
        localProxChao.x = 249;
        StartCoroutine(CriaChao());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator CriaChao()
    {
        yield return new WaitForSeconds(1);
        GameObject aux = Instantiate(chao, localProxChao, chao.transform.rotation);
        localProxChao.x += 249;
        Destroy(aux, 10f);
        StartCoroutine(CriaChao());
    }
}
