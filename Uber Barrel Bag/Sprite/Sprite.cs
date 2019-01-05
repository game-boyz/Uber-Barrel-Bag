using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;
using Uber_Barrel_Bag.type;

/// <summary>
/// 
/// </summary>
namespace Uber_Barrel_Bag.type {
    public class Sprite {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public bool Loop { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int startFrame;
        private int endFrame;
        private Animation currentAnimation;
        private Hashtable Animations;

        /// <summary>
        /// Initialize a spritesheet as an animatable sprite.
        /// </summary>
        /// <remarks>Looping sprite animations are enabled by default</remarks>
        /// <param name="texture">Desired spritesheet; Imported by Content Manager</param>
        /// <param name="rows">The number of rows in the spritesheet</param>
        /// <param name="columns">The number of columns in the spritesheet</param>
        public Sprite(Texture2D texture, int rows, int columns) {
            Init(texture, rows, columns, true);
        }

        /// <summary>
        /// Initialize a spritesheet as an animatable sprite
        /// </summary>
        /// <param name="texture">Desired spritesheet; Imported by Content Manager</param>
        /// <param name="rows">The number of rows in the spritesheet</param>
        /// <param name="columns">The number of columns in the spritesheet</param>
        /// <param name="loop">Enable animation looping when the spritesheet reaches the end</param>
        public Sprite(Texture2D texture, int rows, int columns, bool loop) {
            Init(texture, rows, columns, loop);
        }

        /// <summary>
        /// Internally initialize a spritesheet as an animatable sprite
        /// </summary>
        /// <remarks>This function is used for overloaded constructors</remarks>
        /// <param name="texture">Desired spritesheet; Imported by Content Manager</param>
        /// <param name="rows">The number of rows in the spritesheet</param>
        /// <param name="columns">The number of columns in the spritesheet</param>
        /// <param name="loop">Enable animation looping when the spritesheet reaches the end</param>
        private void Init(Texture2D texture, int rows, int columns, bool loop) {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            startFrame = 0;
            endFrame = 0;
            totalFrames = Rows * Columns;
            Loop = true;
            Animations = new Hashtable();
        }

        /// <summary>
        /// Increment the current sprite frame, loop if looping is enabled
        /// </summary>
        public void Update() {
            if (currentFrame < totalFrames || currentFrame < endFrame) {
                currentFrame++;
            }
            else if (Loop) {
                currentFrame = startFrame;
            }
        }

        /// <summary>
        /// Add playable animations to this sprite
        /// </summary>
        /// <param name="animation">Animation object containing frames for this sprite's spritesheet</param>
        public void RegisterAnimation(Animation animation) {
            Animations.Add(animation.Name, animation);
        }

        /// <summary>
        /// Play a registered animation
        /// </summary>
        /// <param name="animation">Name of the animation you wish to play</param>
        public void Play(string animation) {
            if (Animations.ContainsKey(animation)) {
                currentAnimation = (Animation)Animations[animation];
                startFrame = (int)currentAnimation.Frames.X;
                endFrame = (int)currentAnimation.Frames.Y;
                currentFrame = startFrame;
            }
        }

        /// <summary>
        /// Draw the sprite in the current frame of the spritesheet
        /// </summary>
        /// <param name="spriteBatch">The destination spriteBatch to draw the sprite frame into</param>
        /// <param name="location">The x,y coordinates to draw the sprite frame onto</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 location) {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}