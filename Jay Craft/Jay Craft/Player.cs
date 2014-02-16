using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Jay_Craft
{
    public class Player
    {
        public Vector3 position = Vector3.Zero;
        public float leftrightRot = MathHelper.PiOver2;
        public float updownRot = -MathHelper.Pi / 10f;
        public const float rotationSpeed = 0.3f;
        public const float moveSpeed = 30f;

        public Player(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
        }
    }
}
