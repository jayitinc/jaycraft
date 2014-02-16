using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jay_Craft
{
    public class Block
    {
        public Vector3 position;

        private VertexBuffer vertexBuffer;
        private Matrix world;

        public Block(int x, int y, int z, Game1 game)
        {
            position = new Vector3(x, y, z);

            world = Matrix.CreateTranslation(position);

            VertexPositionColor[] verticies = new VertexPositionColor[30];
            verticies[0] = new VertexPositionColor(new Vector3(x, y, z), Color.Blue);
            verticies[1] = new VertexPositionColor(new Vector3(x + 1, y, z), Color.Blue);
            verticies[2] = new VertexPositionColor(new Vector3(x, y + 1, z), Color.Blue);
            verticies[3] = new VertexPositionColor(new Vector3(x, y + 1, z), Color.Green);
            verticies[4] = new VertexPositionColor(new Vector3(x + 1, y + 1, z), Color.Green);
            verticies[5] = new VertexPositionColor(new Vector3(x + 1, y, z), Color.Green);
            verticies[6] = new VertexPositionColor(new Vector3(x + 1, y, z), Color.Red);
            verticies[7] = new VertexPositionColor(new Vector3(x + 1, y + 1, z), Color.Red);
            verticies[8] = new VertexPositionColor(new Vector3(x + 1, y, z + 1), Color.Red);
            verticies[9] = new VertexPositionColor(new Vector3(x + 1, y + 1, z), Color.Yellow);
            verticies[10] = new VertexPositionColor(new Vector3(x + 1, y + 1, z + 1), Color.Yellow);
            verticies[11] = new VertexPositionColor(new Vector3(x + 1, y, z + 1), Color.Yellow);
            verticies[12] = new VertexPositionColor(new Vector3(x + 1, y + 1, z), Color.Violet);
            verticies[13] = new VertexPositionColor(new Vector3(x, y + 1, z), Color.Violet);
            verticies[14] = new VertexPositionColor(new Vector3(x + 1, y + 1, z + 1), Color.Violet);
            verticies[15] = new VertexPositionColor(new Vector3(x, y + 1, z), Color.Turquoise);
            verticies[16] = new VertexPositionColor(new Vector3(x, y + 1, z + 1), Color.Turquoise);
            verticies[17] = new VertexPositionColor(new Vector3(x + 1, y + 1, z + 1), Color.Turquoise);
            verticies[18] = new VertexPositionColor(new Vector3(x, y, z), Color.White);
            verticies[19] = new VertexPositionColor(new Vector3(x, y + 1, z), Color.White);
            verticies[20] = new VertexPositionColor(new Vector3(x, y, z + 1), Color.White);
            verticies[21] = new VertexPositionColor(new Vector3(x, y + 1, z), Color.Black);
            verticies[22] = new VertexPositionColor(new Vector3(x, y + 1, z + 1), Color.Black);
            verticies[23] = new VertexPositionColor(new Vector3(x, y, z + 1), Color.Black);
            verticies[24] = new VertexPositionColor(new Vector3(x, y, z + 1), Color.YellowGreen);
            verticies[25] = new VertexPositionColor(new Vector3(x + 1, y, z + 1), Color.YellowGreen);
            verticies[26] = new VertexPositionColor(new Vector3(x, y + 1, z + 1), Color.YellowGreen);
            verticies[27] = new VertexPositionColor(new Vector3(x, y + 1, z + 1), Color.SandyBrown);
            verticies[28] = new VertexPositionColor(new Vector3(x + 1, y + 1, z + 1), Color.SandyBrown);
            verticies[29] = new VertexPositionColor(new Vector3(x + 1, y, z + 1), Color.SandyBrown);

            vertexBuffer = new VertexBuffer(game.GraphicsDevice, typeof(VertexPositionColor), 30, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(verticies);
        }

        public void Update(Game1 game)
        {
            world = Matrix.CreateTranslation(position);
        }

        public void Draw(Game1 game)
        {
            game.basicEffect.World = world;
            game.basicEffect.View = game.view;
            game.basicEffect.Projection = game.projection;
            game.basicEffect.VertexColorEnabled = true;

            game.GraphicsDevice.SetVertexBuffer(vertexBuffer);

            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            game.GraphicsDevice.RasterizerState = rasterizerState;

            foreach (EffectPass pass in game.basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                game.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 10);
            }
        }
    }
}
