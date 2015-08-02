using UnityEngine;

namespace Assets.Scripts.Map
{
    public class Map : MonoBehaviour
    {
        public Texture2D SpriteSheet;
        public int TileSize;

        private Texture2D[] _atlastTexture;

        void Start()
        {
            var width = SpriteSheet.width / TileSize;
            var height = SpriteSheet.height / TileSize;

            _atlastTexture = new Texture2D[width * height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var textureColor = SpriteSheet.GetPixels(x * TileSize, y * TileSize, TileSize, TileSize);
                    var newTexture = new Texture2D(TileSize, TileSize);
                    newTexture.SetPixels(0, 0, TileSize, TileSize, textureColor);

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