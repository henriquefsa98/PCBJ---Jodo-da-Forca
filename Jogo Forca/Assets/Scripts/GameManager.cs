using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int numTentativas; // Aqui armazenamos as tentativas válidas da rodada
    private int maxNumTentativas; // Aqui armazenamos o núm. max. de tentativas para forca (derrota) ou salvação (vitória)

    int score = 0;

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

        numTentativas = 0;

        maxNumTentativas = (palavraOculta.Length / 2) + 1;

        UpdateNumTentativas();

        UpdateScore();
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

        //int indexAleatorio = Random.Range(0, palavrasOcultas.Length);

        //palavraOculta = palavrasOcultas[indexAleatorio];

        palavraOculta = EscolhePalaravra();

        Debug.Log("palavra escolhida aleatoriamente = " + palavraOculta + " !");

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
                
                numTentativas++;
                bool verificaAcerto=false;

                for(int i =0; i<tamanhoPalavra; i++)
                {
                    if(!letrasDescobertas[i])
                    {

                        letraTeclada = System.Char.ToUpper(letraTeclada);
                        
                        if(letrasOcultas[i] == letraTeclada)
                        {
                        
                            verificaAcerto = true;
                            letrasDescobertas[i] = true;
                            GameObject.Find("letra " + (i+1)).GetComponent<Text>().text = letraTeclada.ToString();
                            score = PlayerPrefs.GetInt("score");
                            score++;
                            PlayerPrefs.SetInt("score", score);
                            UpdateScore(); 

                            if(score >= palavraOculta.Length)
                            {
                                Debug.Log("Ganhou!");
                                Debug.Log("score = " + score);
                                Debug.Log("tamanho da palavra = " + palavraOculta.Length);

                                SceneManager.LoadScene("winScene");

                            }
                        }

                    }
                }

                if(verificaAcerto){

                    numTentativas--;
                }

                if(numTentativas > maxNumTentativas){

                    PlayerPrefs.SetString("ultimaPalavra", palavraOculta);

                    SceneManager.LoadScene("gameOverScene");

                }

                UpdateNumTentativas();
            }

        }
    }

    void UpdateNumTentativas()
    {
        GameObject.Find("numTentativas").GetComponent<Text>().text = numTentativas + " | " + maxNumTentativas;
    }

    void UpdateScore()
    {
        GameObject.Find("scoreUI").GetComponent<Text>().text = "Score " + score;
    }


    string EscolhePalaravra()
    {
        TextAsset BDPalavras = (TextAsset)Resources.Load("bancoDePalavras", typeof(TextAsset));

        string palavrao = BDPalavras.text;

        string[] palavras = palavrao.Split(' ');

        int indexAleatorio = Random.Range(0, palavras.Length-1);

        return palavras[indexAleatorio];

    }

}
