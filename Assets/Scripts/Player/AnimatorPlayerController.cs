using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayerController : MonoBehaviour
{
    public static class Params
    {
        public const string Speed = nameof(Speed);
        public const string VelocityY = nameof(VelocityY);
        public const string isGround = nameof(isGround);
    }

    public static class States
    {
        public const string Idle = nameof(Idle);
        public const string Run = nameof(Run);
        public const string Jump = nameof(Jump);
    }
}
