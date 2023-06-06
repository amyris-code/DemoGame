using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment",menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;

    public SkinnedMeshRenderer mesh;

    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;

    public int damageModifier;

    public override void Use()
    {
        base.Use();
        //Equip the Item
        EquipmentManager.instance.Equip(this);

        //Remove in the Inventory
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head,Chest,Leg,Weapon,Shield,Feet}
public enum EquipmentMeshRegion { Legs,Arms,Torso}
