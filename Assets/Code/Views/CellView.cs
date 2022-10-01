using System;
using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace Views
{
    public class CellView : MonoBehaviour
    {
        [Serializable]
        public class TypedView
        {
            [SerializeField] private CellModel.Type type;
            [SerializeField] private GameObject view;

            public CellModel.Type Type => type;
            public GameObject View => view;
        }

        [SerializeField] private TypedView[] typedViews;

        private CellModel _model;

        public void Init(CellModel model, Func<Vector2Int, Vector3> worldPositionProvider)
        {
            _model = model;

            gameObject.name = $"Cell {_model.Position}";
            transform.position = worldPositionProvider.Invoke(_model.Position);
            
            foreach (var typedView in typedViews)
            {
                typedView.View.SetActive(typedView.Type == _model.EType);
            }
        }
    }
}