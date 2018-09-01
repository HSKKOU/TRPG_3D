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
        /// フィールド作成
        /// </summary>
        private class GameStateCreateField : State<GameManager>
        {
            /// <summary>
            /// このステートで使用するシーン名
            /// </summary>
            private const Defines.SceneName SCENE_NAME = Defines.SceneName.CreateField;

            /// <summary>
            /// このステートで使用するシーン
            /// </summary>
            private Scene m_Scene;


            public GameStateCreateField(GameManager owner) : base(owner) { /* do nothing */ }


#region Implements of State

            public override void Enter()
            {
                SceneManager.LoadScene(SCENE_NAME.ToString("g"), LoadSceneMode.Additive);
                m_Scene = SceneManager.GetSceneByName(SCENE_NAME.ToString("g"));
            }

            public override void Exit()
            {
                SceneManager.UnloadSceneAsync(m_Scene);
            }

#endregion // Implements of State
        }
    }
}