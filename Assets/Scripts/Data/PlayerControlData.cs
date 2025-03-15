using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControlData", menuName = "PlayerControlData/New PlayerControlData")]
public class PlayerControlData : ScriptableObject
{
    // Key di chuyen
    public KeyCode keyA;
    public KeyCode keyS;
    public KeyCode keyW;
    public KeyCode keyD;
    // Key chieu
    public KeyCode keyU;
    public KeyCode keyI;
    public KeyCode keyO;
    public KeyCode keyP;

    public KeyCode keySpace;
}
