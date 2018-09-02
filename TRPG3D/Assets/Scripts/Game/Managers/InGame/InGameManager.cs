using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils.StateMachine;

namespace Game
{
	// インゲームの状態
	public enum InGameState
	{
		Init,			// 初期化
		Playing,		// ゲーム中
		Num
	}

	/// <summary>
	/// インゲーム管理
	/// </summary>
	public partial class InGameManager : StatefulSingletonMono<InGameManager, InGameState>
	{
#region Implements of StatefulSingletonMono

		public override void Initialize()
		{
			base.Initialize();

			m_StateList.Add(new InGameStateInit(this));
			m_StateList.Add(new InGameStatePlaying(this));

			ChangeState(InGameState.Init);
		}

#endregion // Implements of StatefulSingletonMono
	}
}
