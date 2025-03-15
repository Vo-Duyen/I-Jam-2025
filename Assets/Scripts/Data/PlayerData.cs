using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData/new PlayerData")]
public class PlayerData : ScriptableObject
{
    public float jump;
    public float speed;
    public TimeSkill timeSkill;
    public int countShadow;
    public float distance;
}

[System.Serializable]
public struct TimeSkill
{
    public float speedUp;
    public float teleportation;
    public float reverseShadow;
    public float magicEye;
}
