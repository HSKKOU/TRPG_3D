using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils.StateMachine;

namespace Game
{
    public partial class InGameManager
    {
        /// <summary>
        /// インゲーム初期化
        /// </summary>
        private class InGameStateInit : State<InGameManager>
        {
            public InGameStateInit(InGameManager owner) : base(owner) { /* do nothing */ }


#region Implements of State

            public override void Enter()
            {
                // Net.TRPGNetworkManager.I.ReplacePlayer();

                m_Owner.ChangeState(InGameState.Playing);
            }

#endregion // Implements of State
        }
    }
}