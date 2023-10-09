using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RandomPlayer : MonoBehaviour
{
    public int PlayerNum=5;
    private TextMeshProUGUI luckyText, normalText, unluckyText; 
    private float luckyPossibility=0.3f, normalPossibility=0.6f,unluckyPossibility=0.1f;
    private int luckyNum=0,normalNum=0,unluckyNum=0;
    private float playerBonus=1f;
    private List<float> players=new List<float>();
    void Start()
    {
        float tmp;
        for(int i=0;i<PlayerNum;i++){
            tmp=Random.Range(0f,luckyPossibility+normalPossibility+unluckyPossibility);
            if(tmp<luckyPossibility){
                //players.Add(0.1f);
                playerBonus+=0.1f;
                luckyNum++;
            }
            else if(tmp<luckyPossibility+normalPossibility){
                //players.Add(1f);
                normalNum++;
            }
            else{
                //players.Add(-0.05f);
                playerBonus-=0.05f;
                unluckyNum++;
            }
        }

        luckyText=GameObject.Find("LuckyText").GetComponent<TextMeshProUGUI>();
        normalText=GameObject.Find("NormalText").GetComponent<TextMeshProUGUI>();
        unluckyText=GameObject.Find("UnluckyText").GetComponent<TextMeshProUGUI>();

        luckyText.text="x"+luckyNum;
        normalText.text="x"+normalNum;
        unluckyText.text="x"+unluckyNum;
    }

    public void checkPlayers(){
        GameObject.Find("Player").GetComponent<Player>().RewardCalculate(playerBonus);
        SceneManager.LoadScene("Result");
        GameObject.Find("Player").GetComponent<Player>().GoResult();
    }
}
