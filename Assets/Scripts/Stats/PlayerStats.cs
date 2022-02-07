using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{

    public GameObject deathText;
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }

    }

    public override void Die()
    {
        deathText.gameObject.SetActive(true);
        Debug.Log("test");
        StartCoroutine(deathScreen());
      
    }
    IEnumerator deathScreen()
    {
        PlayerController.isMovable = false;
        yield return new WaitForSeconds(2f);
        base.Die();
        PlayerManager.instance.KillPlayer();
        PlayerController.isMovable = true;
    }
}
