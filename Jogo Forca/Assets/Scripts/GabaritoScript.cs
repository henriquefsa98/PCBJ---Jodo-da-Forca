using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GabaritoScript : MonoBehaviour
{
    // Esse script é utilizado para colocar a última palavra na tela de Game Over
    void Start()
    {
        GameObject.Find("palavraOculta").GetComponent<Text>().text = PlayerPrefs.GetString("ultimaPalavra");
    }

}
