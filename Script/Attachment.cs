using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Attachment : MonoBehaviour
{
    public string attachmentName;
    public int price;
    public bool avairability=false;
    public int numOfAttachment;
    public float reward;

    void Start(){
        GameObject.Find("Player").GetComponent<Player>().PurchaseStart();
        attachmentName=(string)this.gameObject.name;
        this.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text=""+price;
    }
}
