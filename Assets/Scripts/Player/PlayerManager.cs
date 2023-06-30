using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerUIManager playerUIManager;
    bool weaponEquipped;

    void Start()
    {
        playerUIManager.SetActiveControllerMessage(false);
    }

    public PlayerUIManager GetPlayerUIManager() { return playerUIManager; }

    public void SetWeaponEquipped(bool equipped) { weaponEquipped = equipped;  }

    public bool GetWeaponEquipped() { return weaponEquipped; }
}
