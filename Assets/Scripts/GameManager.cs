using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int pontos = 0;
    [SerializeField]
    TextMeshProUGUI text;
    public bool gameOver = false;
    float currentTime = 0;
    public bool gamestart = false;

    public static GameManager gameManager;

    [SerializeField]
    GameObject start_hud, game_over_hud;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameManager);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
        text.text = pontos.ToString();
        AudioManager.audioManager.audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestart==true){
            Time.timeScale=1;
        }else{
            game_over_hud.SetActive(false);
            Time.timeScale=0;
        }
        if (Time.time > currentTime + 0.2f && gameOver == false)
        {
            pontos++;
            text.text = pontos.ToString();
            currentTime = Time.time;
        }
        else if (gameOver)
        {
            AudioManager.audioManager.audioSource.Stop();
            game_over_hud.SetActive(true);
        }
    }
    public void restart()
    {
        gameOver = false;
        pontos = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void init_game()
    {
        AudioManager.audioManager.audioSource.Play();
        start_hud.SetActive(false);
        gamestart=true;
    }
    public void startGame()
    {
        text = GameObject.Find("Pontuacao").GetComponent<TextMeshProUGUI>();
        start_hud = GameObject.Find("Start_HUD");
        game_over_hud = GameObject.Find("Game_over_HUD");
        start_hud.GetComponentInChildren<Button>().onClick.AddListener(init_game);
        game_over_hud.GetComponentInChildren<Button>().onClick.AddListener(restart);
        gamestart=false;
        //Time.timeScale = 0;
        //child_game_over[0].GetComponent<TextMeshProUGUI>().enabled = false;
        //child_game_over[1].GetComponent<Image>().enabled = false;
        //child_game_over[1].GetComponentInChildren<Text>().enabled = false;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        startGame();
    }
}
