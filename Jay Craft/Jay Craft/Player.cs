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

        private float speed = 5;

        public Player(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
        }

        public void Update(Game1 game, float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position += Vector3.Forward * speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position += Vector3.Backward * speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position += Vector3.Left * speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position += Vector3.Right * speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                position += Vector3.Up * speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                position += Vector3.Down * speed * deltaTime;
            }
        }
    }
}
