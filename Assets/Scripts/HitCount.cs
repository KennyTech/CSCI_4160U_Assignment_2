using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCount : MonoBehaviour
{
    private int hitCount = 0;

    public void AddHitCount(int val)
    {
        hitCount += val;
        this.GetComponent<Text>().text = "Hit Count: " + hitCount.ToString();
    }
}
