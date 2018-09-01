using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Utils.StateMachine;

namespace Game
{
    public partial class GameManager
    {
        /// <summary>
        /// ゲーム初期化
        /// </summary>
        private class GameStateTestNetwork : State<GameManager>
        {
            public GameStateTestNetwork(GameManager owner) : base(owner) { /* do nothing */ }

            public override void Enter()
            {
                SceneManager.LoadScene("NetworkTest", LoadSceneMode.Additive);
            }
        }
    }
}