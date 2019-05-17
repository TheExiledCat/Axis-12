using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI cointext;
    public TextMeshProUGUI keytext;
    public PickUp p;
    // Start is called before the first frame update
    private void OnGUI()
    {
        cointext.text = "X "+p.items[0].amount.ToString("000");
        keytext.text = "X  " + p.items[1].amount.ToString("00");
    }
}
