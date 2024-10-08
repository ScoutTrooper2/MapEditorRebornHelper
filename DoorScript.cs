using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoorEnums
{
    public enum KeycardPermissions
    {
        None = 0,
        Checkpoints = 1,
        ExitGates = 2,
        Intercom = 4,
        AlphaWarhead = 8,
        ContainmentLevelOne = 0x10,
        ContainmentLevelTwo = 0x20,
        ContainmentLevelThree = 0x40,
        ArmoryLevelOne = 0x80,
        ArmoryLevelTwo = 0x100,
        ArmoryLevelThree = 0x200,
        ScpOverride = 0x400
    }
    public enum DoorDamageType : byte
    {
        None = 1,
        ServerCommand = 2,
        Grenade = 4,
        Weapon = 8,
        Scp096 = 0x10
    }
    public enum DoorType : byte
    {
        DoorHCZ = 1,
        DoorEZ = 2,
        DoorLCZ = 3,
    }
}
public class DoorScript : MonoBehaviour
{
    [Header("Door Settings")]
    [Tooltip("Prefab used for previewing the door.")]
    public GameObject PreviewPrefab;

    [Tooltip("Name of the door.")]
    public string Name;

    [Tooltip("Health of the door.")]
    public uint DoorHealth = 150;

    [Tooltip("Can players interact with this door (Not worked)?")]
    public bool AllowToInteract = true;

    [Tooltip("Is the door locked?")]
    public bool IsLocked = false;

    [Tooltip("Type of the door.")]
    public DoorEnums.DoorType DoorType = DoorEnums.DoorType.DoorEZ;

    [Tooltip("Required permissions to open this door.")]
    public KeycardPermissions DoorRequiredPermissions = KeycardPermissions.None;

    [Tooltip("Types of damage that are ignored by this door.")]
    public DoorEnums.DoorDamageType DoorIgnoredDamages = DoorEnums.DoorDamageType.None;
}