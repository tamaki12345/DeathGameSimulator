using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    private TextMeshProUGUI resultText, totalText;
    private Player player;

    void Start(){
        resultText=GameObject.Find("resultText").GetComponent<TextMeshProUGUI>();
        totalText=GameObject.Find("totalText").GetComponent<TextMeshProUGUI>();
        player=GameObject.Find("Player").GetComponent<Player>();

        player.CheckResult(resultText, totalText);
    }
}
