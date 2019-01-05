using Microsoft.Xna.Framework;

namespace Uber_Barrel_Bag.type {
   public class Animation {
        public string Name { get; set;  }
        public Vector2 Frames { get; set; }

        public Animation(string name, Vector2 frames) {
            init(name, frames);
        }

        private void init(string name, Vector2 frames) {
            Name = name;
            Frames = frames;
        }
    }
}
