using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossUI : MonoBehaviour
{
    public Image img;
    int hp;
    
    private void Update()
    {
        if (GameObject.Find("Mothera")!=null)
        img.fillAmount = (float)GameObject.Find("Mothera").GetComponent<Mothera>().hp / (float)GameObject.Find("Mothera").GetComponent<Mothera>().maxHp;
    }
}
