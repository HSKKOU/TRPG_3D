using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils.StateMachine;

namespace Game
{
    public partial class GameManager
    {
        /// <summary>
        /// インゲーム
        /// </summary>
        private class GameStateInGame : State<GameManager>
        {
            public GameStateInGame(GameManager owner) : base(owner) { /* do nothing */ }
        }
    }
}