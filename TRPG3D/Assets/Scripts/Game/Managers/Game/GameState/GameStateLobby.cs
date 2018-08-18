using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils.StateMachine;

namespace Game
{
    public partial class GameManager
    {
        /// <summary>
        /// ロビー
        /// </summary>
        private class GameStateLobby : State<GameManager>
        {
            public GameStateLobby(GameManager owner) : base(owner) { /* do nothing */ }
        }
    }
}