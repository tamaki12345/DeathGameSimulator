using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static int money=1000000;
    private static int day=1;
    private static float arrangeBonus=0f;
    private List<Attachment> cart=new List<Attachment>();
    private int totalPayment=0;
    private static float reward=0;
    private TextMeshProUGUI cartText;

    public void PurchaseStart(){
        cartText=GameObject.Find("CartText").GetComponent<TextMeshProUGUI>();
        GameObject.Find("MoneyText").gameObject.GetComponent<TextMeshProUGUI>().text=money.ToString("N0");
        GameObject.Find("DayText").gameObject.GetComponent<TextMeshProUGUI>().text="DAY"+day;
    }

    public void AddCart(Attachment att){
        if(att.price+totalPayment>Player.money) return;
        if(!this.cart.Contains(att)) cart.Add(att);
        att.numOfAttachment++;
        totalPayment+=att.price;
        string tmp="TOTAL $"+totalPayment.ToString("N0")+"\n\n";
        foreach(var attachment in cart){
            tmp+=attachment.name+" x"+attachment.numOfAttachment+"\n";
        }
        cartText.text=tmp;
    }

    public void Purchase(){
        Player.money-=totalPayment;
        foreach(var att in cart){
            Player.arrangeBonus+=att.reward;
        }
        DebugReward();
        SceneManager.LoadScene("RandomPlayer");
    }

    public void RewardCalculate(float bonus){
        Player.reward=arrangeBonus*bonus;
    }

    public void CheckResult(TextMeshProUGUI resultText, TextMeshProUGUI totalText){
        resultText.text=reward.ToString("N0")+"円";
        money+=(int)reward;
        //reward=0;
        totalText.text=money.ToString("N0")+"円";
    }

    public void GoNextGame(){
        day++;
        reward=0;
        arrangeBonus=0f;
        SceneManager.LoadScene("Purchase");
        GameObject.Find("DayText").gameObject.GetComponent<TextMeshProUGUI>().text="DAY"+day;
        //PurchaseStart();
    }

    public void GoResult(){
        DebugReward();
        GameObject.Find("DayText").gameObject.GetComponent<TextMeshProUGUI>().text="DAY"+day;
    }

    public void DebugReward(){
        //Debug.Log("bonus:"+arrangeBonus);
        //Debug.Log("reward:"+reward);
    }
}
