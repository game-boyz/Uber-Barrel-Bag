using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Uber_Barrel_Bag.type;

namespace Uber_Barrel_Bag.type {
    class Player {
        public Vector2 Location;

        private readonly Sprite Sprite;

        public Player(int x, int y, Sprite sprite) {
            Sprite = sprite;
            Location = new Vector2(x, y);

            SetupPlayerAnimations();
        }

        private void SetupPlayerAnimations() {
            List<Animation> animations = new List<Animation>() {
                new Animation("stand", new Vector2(0, 3))
            };

            animations.ForEach(anim => Sprite.RegisterAnimation(anim));
        }

        public void Update() {
            Sprite.Play("stand");
            Sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch) {
            Sprite.Draw(spriteBatch, Location);
        }
    }
}
