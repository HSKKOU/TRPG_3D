using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using Utils.StateMachine;

namespace Game
{
    public partial class InGameManager
    {
        /// <summary>
        /// インゲームプレイ中
        /// </summary>
        private class InGameStatePlaying : State<InGameManager>
        {
            public InGameStatePlaying(InGameManager owner) : base(owner) { /* do nothing */ }


#region Implements of State

            public override void Enter()
            {
            }

#endregion // Implements of State
        }
    }
}