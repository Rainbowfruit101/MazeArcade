using System;
using System.Linq;
using Models;
using UnityEngine;

namespace Views
{
    public class CellView : MonoBehaviour
    {
        [Serializable]
        public class TypedSprite
        {
            [SerializeField] private CellModel.Type type;
            [SerializeField] private Sprite sprite;
            [SerializeField] private bool hasCollider;

            public CellModel.Type Type => type;
            public Sprite Sprite => sprite;
            public bool HasCollider => hasCollider;
        }

        [SerializeField] private new Collider2D collider;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TypedSprite[] typeToSprite;

        private CellModel _model;

        public void Init(CellModel model, Func<Vector2Int, Vector3> worldPositionProvider)
        {
            _model = model;

            transform.position = worldPositionProvider.Invoke(_model.Position);
            var typedSprite = typeToSprite.FirstOrDefault(ts => ts.Type == _model.EType);
            if (typedSprite != null)
            {
                spriteRenderer.sprite = typedSprite.Sprite;
                collider.enabled = typedSprite.HasCollider;
            }
        }
    }
}