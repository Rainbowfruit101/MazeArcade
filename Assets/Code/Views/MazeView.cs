using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using Utils;

namespace Views
{
    [RequireComponent(typeof(Grid))]
    public class MazeView: MonoBehaviour
    {
        [SerializeField] private CellView cellViewPrefab;
        
        private Grid _grid;
        private List<CellView> _views;

        private void Awake()
        {
            _grid = GetComponent<Grid>();
        }

        public void Init(MazeModel model)
        {
            if (_views != null)
            {
                _views.ForEach(e => Destroy(e.gameObject));
                _views.Clear();
            }
            else
            {
                _views = new List<CellView>();
            }
            
            var cells = model.Cells.Cast<CellModel>();

            foreach (var cellModel in cells)
            {
                var instance = Instantiate(cellViewPrefab.gameObject).GetComponent<CellView>();
                instance.Init(cellModel, _grid.WorldPositionProvider);
                instance.transform.SetParent(transform);
                
                _views.Add(instance);
            }
        }
    }
}