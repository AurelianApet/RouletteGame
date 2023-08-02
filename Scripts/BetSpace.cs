using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BetSpace : MonoBehaviour {

    GameObject chipStackGameObject;
    [HideInInspector]
    public ChipStack chipStack;

    public int[] winningNumbers = new int[] { 1 };

    void Start()
    {
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

        chipStackGameObject = Instantiate(Resources.Load<GameObject>("chipstack"));

        chipStackGameObject.transform.position = transform.position;
        chipStackGameObject.transform.parent = transform.parent;

        chipStack = chipStackGameObject.GetComponent<ChipStack>();

        ResultManager.RegisterBetSpace(this);
    }

    void OnMouseOver()
    {
        ToolTipManager.getInstance().target = chipStack;
    }

    void OnMouseOut()
    {
        if (ToolTipManager.getInstance().target == chipStack)
        {
            ToolTipManager.getInstance().target = null;
        }
    }

	void OnMouseDown()
    {
        int selectedValue = ChipManager.GetSelectedValue();

        if (ResultManager.betsEnabled && BalanceManager.getInstance().balance >= selectedValue)
        {
            AudioManager.getInstance().Play("chip", 1.0f);

            BetHistoryManager.getInstance().Add(chipStack, selectedValue);
            chipStack.Add(selectedValue);
        }
    }

   public int ResolveBet(int result)
    {
        int multiplier = 36 / winningNumbers.Length;


        bool won = false;

        foreach (int num in winningNumbers)
        {
            if (num == result)
            {
                won = true;
                break;
            }
        }

        int winAmount = 0;

        if (won)
        {
            winAmount = chipStack.Win(multiplier);
        } else
        {
            chipStack.Clear();
        }

        return winAmount;
    }
}
