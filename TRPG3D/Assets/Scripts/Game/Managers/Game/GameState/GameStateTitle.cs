using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils.StateMachine;

namespace Game
{
    public partial class GameManager
    {
        /// <summary>
        /// タイトル
        /// </summary>
        private class GameStateTitle : State<GameManager>
        {
            public GameStateTitle(GameManager owner) : base(owner) { /* do nothing */ }
        }
    }
}