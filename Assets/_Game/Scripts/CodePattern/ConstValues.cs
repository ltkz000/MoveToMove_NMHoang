using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstValues
{
    //Animation
    public const string ANIM_TRIGGER_IDLE = "Idle";
    public const string ANIM_TRIGGER_RUN = "Run";
    public const string ANIM_TRIGGER_ATTACK = "Attack";
    public const string ANIM_TRIGGER_DEAD = "Dead";
    public const string ANIM_TRIGGER_DANCEWIN = "DanceWin";
    public const string ANIM_TRIGGER_DANCESKIN = "DanceSkin";
    public const float ATTACK_ANIM_TIME = 0.6f;
    public const float DEAD_ANIM_TIME = 1.8f;

    //Tags
    public const string TARGET_TAG = "Target";
    public const string OBSTACLE_TAG = "Obstacle";

    //UI 
    public const string EQUIPPED_TEXT = "EQUIPPED";
    public const string SELECT_TEXT = "SELECT";

    //Gameplay
    public const int MAX_LEVEL = 5;
    public const float DELAY_THROWWEAPON_TIME = 0.3f;
}
