using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 切换装备 : MonoBehaviour
{
    public 玩家战斗 combat;
    public 玩家射箭 bow;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("ChangeEquipment"))
        {
            combat.enabled = !combat.enabled;
            bow.enabled = !bow.enabled;
        }
    }
}
