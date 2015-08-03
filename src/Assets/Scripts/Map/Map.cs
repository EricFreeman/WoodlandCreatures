using UnityEngine;

namespace Assets.Scripts.Map
{
    public class Map : MonoBehaviour
    {
        public Texture2D SpriteSheet;
        public int TileWidth;
        public int TileHeight;

        private Texture2D[] _atlastTexture;

        void Start()
        {
            var width = SpriteSheet.width / TileWidth;
            var height = SpriteSheet.height / TileHeight;

            _atlastTexture = new Texture2D[width * height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var textureColor = SpriteSheet.GetPixels(x * TileWidth, y * TileHeight, TileWidth, TileHeight);
                    var newTexture = new Texture2D(TileWidth, TileHeight);
                    newTexture.SetPixels(0, 0, TileWidth, TileHeight, textureColor);

                    _atlastTexture[x + y * width] = newTexture;
                }
            }
        }

        public Texture2D GetTexture(int index)
        {
            return _atlastTexture[index];
        }
    }
}