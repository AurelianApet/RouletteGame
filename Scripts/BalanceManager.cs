using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BalanceManager : MonoBehaviour {

    public int balance = 1000;

    public Text balanceText;

    static BalanceManager instance;

    public static BalanceManager getInstance()
    {
        return instance;
    }

    void Start()
    {
        instance = this;
    }

	void Update () {
        balanceText.text = balance.ToString();
    }
}
