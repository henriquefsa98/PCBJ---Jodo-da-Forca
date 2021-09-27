using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GabaritoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("palavraOculta").GetComponent<Text>().text = PlayerPrefs.GetString("ultimaPalavra");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
