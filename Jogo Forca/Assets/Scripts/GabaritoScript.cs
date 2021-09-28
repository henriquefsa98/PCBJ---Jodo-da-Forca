// **********          Universidade Federal do ABC          **********
// ********** Programação Baseada em Componentes para Jogos **********
// **********          Laboratório 1: Jogo da Forca         **********
// **********                                               **********
// **********             Componentes do Grupo:             **********
// **********                                               **********
// **********               Henrique Fantato                **********
// **********                   21053916                    **********
// **********                                               **********
// **********                  Leonardo Vaz                 **********
// **********                  11201811616                  **********
// **********                                               **********
// **********                  Santo André                  **********
// **********                     2021                      **********

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
