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
        /// タイトル
        /// </summary>
        private class GameStateTitle : State<GameManager>
        {
            private Scene m_TitleScene;

            public GameStateTitle(GameManager owner) : base(owner) { /* do nothing */ }

            public override void Enter()
            {
                SceneManager.LoadScene("Title", LoadSceneMode.Additive);
                m_TitleScene = SceneManager.GetSceneByName("Title");
            }

            public override void Exit()
            {
                SceneManager.UnloadSceneAsync(m_TitleScene);
            }
        }
    }
}