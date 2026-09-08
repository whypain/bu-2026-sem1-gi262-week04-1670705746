using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPExit : Identity
    {
        public GameObject YouWin;
        // กำหนดชื่อไอเท็มและจำนวนที่ต้องการใช้ในการเปิดทางออก

        public override bool Hit()
        {
            // ตรวจสอบว่าผู้เล่นมีไอเท็มที่ต้องการหรือไม่
            Inventory inv = mapGenerator.player.inventory;

            if (inv.HasItem("Key", 2))
            {
                YouWin.SetActive(true);
                Debug.Log("You win");
                return true;
            }

            Debug.Log($"need 2 keys; You have {inv.GetItemCount("Key")}");
            return false;
        }
    }
}