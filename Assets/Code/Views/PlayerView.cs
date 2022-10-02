using System;
using Controllers;
using Models;
using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerModel _model;
        private PlayerController _controller;
        
        public void Init(PlayerModel model, PlayerController controller, Func<Vector2Int, Vector3> worldPositionProvider)
        {
            _model = model;
            _controller = controller;
            gameObject.name = "Player";
            transform.position = worldPositionProvider.Invoke(_model.Position);
        }
    }
}