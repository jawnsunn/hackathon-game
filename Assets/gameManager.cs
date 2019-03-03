using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField]
    Text playersScore;
    playerController player1State;
    //player2Controller player2State;
    public int p1Wins = 0;
    public int p2Wins = 0;

    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 640, false);
        p1Wins = PlayerPrefs.GetInt("Wins(P1)");
        p2Wins = PlayerPrefs.GetInt("Wins(P2)");

        if (p1Wins > 10)
        {
            PlayerPrefs.DeleteKey("Wins(P1)");
            SceneManager.LoadScene("test", LoadSceneMode.Single);
        }

        if (p2Wins > 10)
        {
            PlayerPrefs.DeleteKey("Wins(P2)");
            SceneManager.LoadScene("test", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("q"))
            p1Wins++;
        if (Input.GetKeyUp("w"))
            p2Wins++;
        playersScore.text = "Wins(P1): " + p1Wins.ToString() + " Wins(P2): " + p2Wins.ToString();
    }

    public void MatchEnd() //needs to be public so that other scripts can access it
    {
        PlayerPrefs.SetInt("Wins(P1)", p1Wins);
        PlayerPrefs.SetInt("Wins(P2)", p2Wins);
        PlayerPrefs.Save();
        SceneManager.LoadScene("test", LoadSceneMode.Single);
    }
}
