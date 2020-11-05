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
       SceneManager.LoadScene("TelaPaciente");
   }

   public void Dados()
   {
       SceneManager.LoadScene("TelaDados");
   }

   public void Configuracao()
   {
       
   }

   public void Fechar()
    {
        Application.Quit();
    }
}
