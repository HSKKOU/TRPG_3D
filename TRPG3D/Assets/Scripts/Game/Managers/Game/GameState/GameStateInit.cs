using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils.StateMachine;

namespace Game
{
    public partial class GameManager
    {
        /// <summary>
        /// ゲーム初期化
        /// </summary>
        private class GameStateInit : State<GameManager>
        {
            public GameStateInit(GameManager owner) : base(owner) { /* do nothing */ }


#region Implements of State

            public override void Enter()
            {
                m_Owner.ChangeState(GameState.Title);
            }

#endregion // Implements of State
        }
    }
}