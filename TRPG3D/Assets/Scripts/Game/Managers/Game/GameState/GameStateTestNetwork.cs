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
        /// ネットワークテスト
        /// </summary>
        private class GameStateTestNetwork : State<GameManager>
        {
            /// <summary>
            /// このステートで使用するシーン名
            /// </summary>
            private const Defines.SceneName SCENE_NAME = Defines.SceneName.NetworkTest;

            /// <summary>
            /// このステートで使用するシーン
            /// </summary>
            private Scene m_Scene;


            public GameStateTestNetwork(GameManager owner) : base(owner) { /* do nothing */ }


#region Implements of State

            public override void Enter()
            {
                SceneManager.LoadScene(SCENE_NAME.ToString("g"), LoadSceneMode.Additive);
            }

#endregion // Implements of State
        }
    }
}