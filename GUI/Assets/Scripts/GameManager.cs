using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject welcomePanel;
    public GameObject gamePanel;
    public static Board globalGameBoard;
    public static Rack globalGameRack;

    // Start is called before the first frame update
    void Start()
    {
        welcomePanel.SetActive(true);
        gamePanel.SetActive(false);
        globalGameBoard = new Board();
        globalGameRack = new Rack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
