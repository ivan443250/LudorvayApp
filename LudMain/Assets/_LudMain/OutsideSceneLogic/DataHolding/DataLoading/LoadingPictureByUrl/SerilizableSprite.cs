using System;
using UnityEngine;

namespace LudMain.DataHolding
{
    [Serializable]
    public class SerilizableSprite 
    {
        //public из-за сериализации
        public int X;
        public int Y;
        public byte[] Bytes;
        public bool IsEmpty;

        private Texture2D _currentTexture;
        private Sprite _currentSprite;

        public SerilizableSprite(Texture2D texture)
        {
            IsEmpty = false;

            if (texture == null)
            {
                IsEmpty = true;
                LoadDefaultSprite();

                return;
            }

            _currentTexture = texture;

            X = _currentTexture.width;
            Y = _currentTexture.height;

            Bytes = ImageConversion.EncodeToPNG(_currentTexture);

            _currentSprite = CreateDefaultSprite(_currentTexture);
        }

        public SerilizableSprite(int x, int y, byte[] bytes, bool isEmpty)
        {
            if (isEmpty)
            {
                IsEmpty = true;
                LoadDefaultSprite();

                return;
            }

            _currentTexture = new Texture2D(x, y);
            ImageConversion.LoadImage(_currentTexture, bytes);

            _currentSprite = CreateDefaultSprite(_currentTexture);
        }

        public Sprite Value 
        {
            get
            {
                if (_currentSprite == null)
                {
                    if (_currentTexture == null)
                    {
                        _currentTexture = new Texture2D(X, Y);
                        ImageConversion.LoadImage(_currentTexture, Bytes);
                    }

                    _currentSprite = CreateDefaultSprite(_currentTexture);
                }

                return _currentSprite;
            }
        }

        private Sprite CreateDefaultSprite(Texture2D texture)
        {
            return Sprite.Create(_currentTexture, new Rect(0.0f, 0.0f, _currentTexture.width, _currentTexture.height), Vector2.one);
        }

        private void LoadDefaultSprite()
        {
            _currentSprite = Resources.LoadAll<Sprite>("DefaultImage")[0];
        }
    }
}

