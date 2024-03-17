using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
   


    public void IraOtra(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void Salir() => Application.Quit();

   
   
       
}
