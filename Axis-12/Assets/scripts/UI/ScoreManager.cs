using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text cointext;
    public Text keytext;
    public PickUp p;
    // Start is called before the first frame update
    private void OnGUI()
    {
        cointext.text = "Coins: "+p.items[0].amount.ToString("000");
        keytext.text = "Keys: " + p.items[1].amount.ToString("000");
    }
}
