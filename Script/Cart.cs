using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private float defaultX;
    void Start(){
        Vector3 pos=this.gameObject.transform.position;
        defaultX=pos.x;
        GameObject.Find("Player").GetComponent<Player>().PurchaseStart();
    }

    private bool pressed=false;
    public void Pressed(){
        Vector3 pos=this.gameObject.transform.position;
        if(!pressed){
            while(pos.x>-defaultX)
            {
                pos.x--;
                this.gameObject.transform.position=pos;
            }
            pressed=true;
        }
        else if(pressed){
            while(pos.x<defaultX)
            {
                pos.x++;
                this.gameObject.transform.position=pos;
            }
            pressed=false;
        }
    }
}
