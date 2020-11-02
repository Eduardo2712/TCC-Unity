using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
   public void Cadastrar()
   {
       SceneManager.LoadScene("Cadastro");
   }

   public void Exercicio()
   {
       SceneManager.LoadScene("TelaInicio");
   }

   public void Dados()
   {

   }

   public void Configuracao()
   {
       
   }
}
