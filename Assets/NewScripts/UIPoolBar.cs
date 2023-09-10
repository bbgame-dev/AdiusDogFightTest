using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoolBar : MonoBehaviour
{
    [SerializeField] Image hpBar;

    ValuePool targetPool;


    public void ShowHP(ValuePool targetPool)
    {
        this.targetPool = targetPool;
        gameObject.SetActive(true);
    }

    public void ChearHP()
    {
        this.targetPool = null;
        gameObject.SetActive(false);
        Debug.Log("Clear HP nanana" + gameObject.name);
    }

    private void Update()
    {
        if(targetPool == null)
        {
            return;
        } 

        hpBar.fillAmount = Mathf.InverseLerp(0f, targetPool.maxValue.integer_value, targetPool.currentValue);
    }
}
