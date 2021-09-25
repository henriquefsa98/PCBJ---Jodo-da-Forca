using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject letra;
    public GameObject centro;

    // TO DO: futuramente serao palavras lidas de um arquivo!

    //private string palavraOculta = "";       // palavra a ser descoberta

    private string palavraOculta = "";
    private string[] palavrasOcultas = new string[] {"carro", "elefante", "jogos"};
    
    private int tamanhoPalavra;              // tamanho da palavra
    char[] letrasOcultas;                    // letras ocultas
    bool[] letrasDescobertas;                // indicador letras descobertas

    // Start is called before the first frame update
    void Start()
    {
        centro = GameObject.Find("centroTela");

        InitGame();

        IniciaLetras();
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckTeclado();

    }

    void IniciaLetras()
    {
        int numLetras = palavraOculta.Length;

        for(int i=0; i< numLetras; i++)
        {
            Vector3 novaPos;

            novaPos = new Vector3(centro.transform.position.x + ((i - numLetras/2.0f) * 80), centro.transform.position.y, centro.transform.position.z);

            GameObject l = (GameObject)Instantiate(letra, novaPos, Quaternion.identity);
            l.name = "letra " + (i + 1);
            l.transform.SetParent(GameObject.Find("Canvas").transform);

        }
    }

    void InitGame()
    {
        //palavraOculta = "Elefante";                         // palavra inicial a ser descoberta

        int indexAleatorio = Random.Range(0, palavrasOcultas.Length);

        palavraOculta = palavrasOcultas[indexAleatorio];

        palavraOculta = palavraOculta.ToUpper();         // tamanho da palavra
        tamanhoPalavra = palavraOculta.Length; 

        letrasOcultas = new char[tamanhoPalavra];        // letras ocultas da palavra

        letrasDescobertas = new bool[tamanhoPalavra];    // letras descobertas da palavra

        letrasOcultas = palavraOculta.ToCharArray();     //
    }

    void CheckTeclado()
    {
        if(Input.anyKeyDown)
        {
            char letraTeclada = Input.inputString.ToCharArray()[0];
            int letraTecladaComoInt = System.Convert.ToInt32(letraTeclada);

            if(letraTecladaComoInt >= 97 && letraTecladaComoInt <= 122)
            {
                for(int i =0; i<tamanhoPalavra; i++)
                {
                    if(!letrasDescobertas[i])
                    {

                        letraTeclada = System.Char.ToUpper(letraTeclada);
                        
                        if(letrasOcultas[i] == letraTeclada)
                        {
                            letrasDescobertas[i] = true;
                            GameObject.Find("letra " + (i+1)).GetComponent<Text>().text = letraTeclada.ToString();
                        }

                    }
                }
            }

        }
    }

}
