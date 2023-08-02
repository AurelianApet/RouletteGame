using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public static class ResultManager {

    public static bool spinning = false;
    public static bool betsEnabled = true;

    public static int result;

    static List<BetSpace> betSpaces = new List<BetSpace>();

    public static void SetResult(int newResult)
    {
        if (spinning)
        {
            spinning = false;

            result = newResult;
            GameObject.Find("high" + result.ToString()).GetComponent<MeshRenderer>().enabled = true;

            int totalWin = 0;

            foreach (BetSpace betSpace in betSpaces)
            {
                totalWin += betSpace.ResolveBet(result);
            }
            
            BalanceManager.getInstance().balance += totalWin;

            BetHistoryManager.getInstance().ClearHistory();

            GameObject.Find("WinSequence").GetComponent<WinSequence>().ShowResult(result, totalWin);
        }
    }

    public static void ClearResult()
    {
        GameObject previousResultHighlight = GameObject.Find("high" + result.ToString());
        if (previousResultHighlight != null) { 
        previousResultHighlight.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public static void RegisterBetSpace(BetSpace betSpace)
    {
        betSpaces.Add(betSpace);
    }
}