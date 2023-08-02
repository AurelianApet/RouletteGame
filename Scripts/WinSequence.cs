using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class WinSequence : MonoBehaviour {

    public GameObject winPanel;
    public Text winText;

    public GameObject buttons;

    public Text resultText;

    public Text redHistoryText;
    public Text blackHistoryText;

    int[] redNumbers = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };

    public void ShowResult(int result, int totalWin)
    {
        CameraManager.getInstance().Bet();

        if (totalWin > 0)
        {
            AudioManager.getInstance().Play("win", 1.0f);
            winPanel.SetActive(true);

            winText.text = totalWin.ToString();
        }

        resultText.text = result.ToString();

        bool isRed = false;

        for (int i = 0; i < redNumbers.Length; i++)
        {
            if (redNumbers[i] == result)
            {
                isRed = true;
                break;
            }
        }

        if (isRed)
        {
            resultText.color = Color.red;
            redHistoryText.text = result.ToString() + "\n" + redHistoryText.text;
            blackHistoryText.text = "\n" + blackHistoryText.text;
        } else
        {
            if (result == 0)
            {
                resultText.color = Color.green;
            } else
            {
                resultText.color = Color.white;
            }
            blackHistoryText.text = result.ToString() + "\n" + blackHistoryText.text;
            redHistoryText.text = "\n" + redHistoryText.text;
        }

        Invoke("EnableBets", 3f);
    }

    public void EnableBets()
    {

        winPanel.SetActive(false);

        buttons.SetActive(true);

        ResultManager.betsEnabled = true;
    }
}
