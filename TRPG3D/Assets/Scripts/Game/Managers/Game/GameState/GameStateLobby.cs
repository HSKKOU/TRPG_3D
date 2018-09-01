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
        /// ロビー
        /// </summary>
        private class GameStateLobby : State<GameManager>
        {
            /// <summary>
            /// このステートで使用するシーン名
            /// </summary>
            private const Defines.SceneName SCENE_NAME = Defines.SceneName.Lobby;

            /// <summary>
            /// このステートで使用するシーン
            /// </summary>
            private Scene m_Scene;


            /// <summary>
            /// ロビー用パラメータ
            /// </summary>
            private GameStateLobbyParam m_Param;


            public GameStateLobby(GameManager owner) : base(owner) { /* do nothing */ }


#region Implements of State

            public override bool SetParameter(object parameter)
            {
                if (parameter != null && parameter is GameStateLobbyParam)
                {
                    m_Param = parameter as GameStateLobbyParam;
                    return true;
                }

                return false;
            }

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


        /// <summary>
        /// ロビーで使用するパラメータ
        /// </summary>
        public class GameStateLobbyParam
        {
            /// <summary>
            /// ホストかどうか？
            /// </summary>
            public bool isHost = false;

            public GameStateLobbyParam(bool isHost)
            {
                this.isHost = isHost;
            }
        }
    }
}