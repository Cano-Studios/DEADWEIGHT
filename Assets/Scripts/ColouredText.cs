using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColouredText : MonoBehaviour
{
     public Text gameTitle;

    void Start()
    {
        string dead = "<color=#f43137>DEAD</color>";
        string weight = "<color=#ffffff>WEIGHT</color>";

        gameTitle.text = dead + weight;
    }
}
