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
using UnityEngine.SceneManagement;

public class ManageBotoes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Função responsável por "inicializar" a tela do gameScene quando chamada
    public void StartMundoGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    // Função responsável por "inicializar" a tela do gameScene quando chamada
    public void RestartMundoGame()
    {
        SceneManager.LoadScene("startScene");
    }
    
    // Função responsável por "inicializar" a tela do gameScene quando chamada
    public void EndMundoGame()
    {
        SceneManager.LoadScene("creditScene");
    }
}
