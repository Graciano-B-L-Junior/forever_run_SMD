using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int pontos=0;
    [SerializeField]
    TextMeshProUGUI text,game_over;
    [SerializeField]
    Button btn_reiniciar;
    public static bool gameOver=false;
    float currentTime=0;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        btn_reiniciar.gameObject.SetActive(false);
        game_over.enabled=false;
        text.text = "Pontuação: "+pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>currentTime+0.2f && gameOver == false){
            pontos++;
            text.text = "Pontuação: "+pontos.ToString();
            currentTime=Time.time;
        }
        if(gameOver){
            btn_reiniciar.gameObject.SetActive(true);
            game_over.enabled=true;
        }
    }
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.gameOver=false;
        pontos=0;
    }
}
