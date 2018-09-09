using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils.StateMachine;

namespace Game
{
	// ゲームの状態
	public enum GameState
	{
		Init,			// 初期化
		Title,			// タイトル

		CreateField,	// フィールド作成

		InGame,			// インゲーム

		TestNetwork,	// ネットワークテスト

		Num
	}

	/// <summary>
	/// ゲーム管理
	/// </summary>
	public partial class GameManager : StatefulSingletonMono<GameManager, GameState>
	{
#region Implements of StatefulSingletonMono

		public override void Initialize()
		{
			base.Initialize();

			m_StateList.Add(new GameStateInit(this));
			m_StateList.Add(new GameStateTitle(this));

			m_StateList.Add(new GameStateCreateField(this));

			m_StateList.Add(new GameStateInGame(this));

			m_StateList.Add(new GameStateTestNetwork(this));

			ChangeState(GameState.Init);
		}

#endregion // Implements of StatefulSingletonMono
	}
}
