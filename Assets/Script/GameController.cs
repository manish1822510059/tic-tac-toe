using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class GameController : MonoBehaviour
{
     public int whoTurn; // 0 = x and 1 = 0
     public int turnCount; //count the number of turn played
     public GameObject[] turnIcons; // display who turn played
     public Sprite[] playerIcon; //0 -x icon and 1 - 0 icon
     public Button[] tictactoeSpaces; // playable space for our game
     public int[] markedSpaces; //ID'S which space
     public TextMeshProUGUI  WinnerText; //Hold the text component of the Winner test
     public GameObject[] winningLine; //Hold all the different line for show then is a winner.
     public GameObject WinnerPanel; // Winner Panel 
     public int xPlayerScore;
     public int yPlayerScore;
     public TextMeshProUGUI  xPlayerScoreText;
     public TextMeshProUGUI  yPlayerScoreText;

    // Start is called before the first frame update
     void Start()
    {
         GameSetUp();
    }
    
    void GameSetUp()
    {
      whoTurn = 0;
      turnCount = 0;
      turnIcons[0].SetActive(true);
      turnIcons[1].SetActive(false);
      for(int i = 0; i < tictactoeSpaces.Length; i++){
           tictactoeSpaces[i].interactable = true;
           tictactoeSpaces[i].GetComponent<Image>().sprite = null;
      }
      for(int i=0; i<markedSpaces.Length;i++){
        markedSpaces[i] = -100;
      }
    }

      public void TicTacToeButton(int whichNumber){
        tictactoeSpaces[whichNumber].image.sprite = playerIcon[whoTurn];
        tictactoeSpaces[whichNumber].interactable = false;
        markedSpaces[whichNumber] = whoTurn+1;
        turnCount++;
        if(turnCount > 4){
            WinnerCheck();
        }
        if(whoTurn == 0){
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);

        }else{
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
      }

      void WinnerCheck(){
        int s1 = markedSpaces[0]+markedSpaces[1]+markedSpaces[2];
        int s2 = markedSpaces[3]+markedSpaces[4]+markedSpaces[5];
        int s3 = markedSpaces[6]+markedSpaces[7]+markedSpaces[8];
        int s4 = markedSpaces[0]+markedSpaces[3]+markedSpaces[6];
        int s5 = markedSpaces[1]+markedSpaces[4]+markedSpaces[7];
        int s6 = markedSpaces[2]+markedSpaces[5]+markedSpaces[8];
        int s7 = markedSpaces[0]+markedSpaces[4]+markedSpaces[8];
        int s8 = markedSpaces[2]+markedSpaces[4]+markedSpaces[6];
        var solutions  = new int[]{s1, s2, s3, s4, s5,s6, s7, s8};
        for (int i = 0; i < solutions.Length; i++)
        {
            if(solutions[i]  ==  3*(whoTurn+1))
            {
            WinnerDisplay(i);
            return;
            }
        }

      }

      void WinnerDisplay(int indexIn){
        WinnerPanel.gameObject.SetActive(true);
        if(whoTurn == 0){
            xPlayerScore++;
            xPlayerScoreText.text = xPlayerScore.ToString();
            WinnerText.text = "Player X Wins!";
        }else if(whoTurn == 1){
            yPlayerScore++;
            yPlayerScoreText.text = yPlayerScore.ToString();;
            WinnerText.text = "Player O Wins!";
        }
        winningLine[indexIn].SetActive(true);
      }

      public void Rematch(){
        GameSetUp();
        for(int i = 0 ;i<winningLine.Length;i++){
            winningLine[i].SetActive(false);
        }
        WinnerPanel.SetActive(false);
      }

      public void Restart(){
        Rematch();
        xPlayerScore = 0;
        yPlayerScore = 0;
        xPlayerScoreText.text = "0";
        yPlayerScoreText.text = "0";
      }
}


