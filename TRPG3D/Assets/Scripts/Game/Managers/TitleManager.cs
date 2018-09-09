using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Utils;

namespace Game
{
	/// <summary>
	/// タイトル画面
	/// </summary>
	public class TitleManager : SingletonMono<TitleManager>
	{
		/// <summary>
		/// ルーム作成情報を入力
		/// </summary>
		[SerializeField]
		private UIRoomInoutLightbox m_MakeRoomInfoInput;

		/// <summary>
		/// ルーム入場情報を入力
		/// </summary>
		[SerializeField]
		private UIRoomInoutLightbox m_EnterRoomInfoInput;

		/// <summary>
		/// マッチメーカーのローディングメッセージ
		/// </summary>
		[SerializeField]
		private Text m_LoadingMessageText;

		/// <summary>
		/// マッチメイカー
		/// </summary>
		[SerializeField]
		private Net.MatchMaker m_MatchMaker;



#region MonoBehaviour Message

		private void Awake()
		{
			m_MakeRoomInfoInput.onRequestRoomInfoEvent += MakeRoom;
			m_MakeRoomInfoInput.onCancelEvent += CloseMakeRoomInfoInput;
			m_EnterRoomInfoInput.onRequestRoomInfoEvent += EnterRoom;
			m_EnterRoomInfoInput.onCancelEvent += CloseEnterRoomInfoInput;

			m_MatchMaker.onShowLoadingText += UpdateMatchMakingText;
		}

		private void Start()
		{
			UIManager.I.onClickFilterEvent += CloseMakeRoomInfoInput;
			UIManager.I.onClickFilterEvent += CloseEnterRoomInfoInput;
		}

		private void OnDestroy()
		{
			if (m_MakeRoomInfoInput != null)
			{
				m_MakeRoomInfoInput.onRequestRoomInfoEvent -= MakeRoom;
				m_MakeRoomInfoInput.onCancelEvent -= CloseMakeRoomInfoInput;
			}
			if (m_EnterRoomInfoInput != null)
			{
				m_EnterRoomInfoInput.onRequestRoomInfoEvent -= EnterRoom;
				m_EnterRoomInfoInput.onCancelEvent -= CloseEnterRoomInfoInput;
			}

			if (m_MatchMaker != null)
			{
				m_MatchMaker.onShowLoadingText -= UpdateMatchMakingText;
			}
		}

#endregion // MonoBehaviour Message


#region マッチマイカー

		/// <summary>
		/// ルーム作成
		/// </summary>
		private void MakeRoom(Net.MatchRoomInfo info)
		{
			m_MatchMaker.CreateInternetMatch(info,
			() => {
				GameManager.I.ChangeState(GameState.InGame);
			},
			() => {
				// do nothing
			});
		}

		/// <summary>
		/// ルーム入場
		/// </summary>
		private void EnterRoom(Net.MatchRoomInfo info)
		{
			m_MatchMaker.EnterInternetMatch(info,
			() => {
				GameManager.I.ChangeState(GameState.InGame);
			},
			() => {
				// do nothing
			});
		}

#endregion // マッチマイカー


#region UI

		/// <summary>
		/// ルームを作成するボタンを押された
		/// </summary>
		public void OnClickMakeRoomButton()
		{
			UIManager.I.ShowFilter(true);
			m_MakeRoomInfoInput.gameObject.SetActive(true);
		}

		/// <summary>
		/// ルームに入るボタンを押された
		/// </summary>
		public void OnClickEnterRoomButton()
		{
			UIManager.I.ShowFilter(true);
			m_EnterRoomInfoInput.gameObject.SetActive(true);
		}

		/// <summary>
		/// フィールドを作るボタンを押された
		/// </summary>
		public void OnClickCreateFieldButton()
		{
			GameManager.I.ChangeState(GameState.CreateField);
		}

		/// <summary>
		/// ネットワークテストを開く
		/// </summary>
		public void OnClickTestButton()
		{
			GameManager.I.ChangeState(GameState.TestNetwork);
		}


		/// <summary>
		/// ルーム作成画面を閉じる
		/// </summary>
		private void CloseMakeRoomInfoInput()
		{
			if (m_MakeRoomInfoInput != null)
			{
				m_MakeRoomInfoInput.gameObject.SetActive(false);
			}
			UIManager.I.HideFilter();
		}

		/// <summary>
		/// ルーム入場画面を閉じる
		/// </summary>
		private void CloseEnterRoomInfoInput()
		{
			if (m_EnterRoomInfoInput != null)
			{
				m_EnterRoomInfoInput.gameObject.SetActive(false);
			}
			UIManager.I.HideFilter();
		}


		/// <summary>
		/// マッチメーカーの状態文字列を表示する
		/// </summary>
		private void UpdateMatchMakingText(string text)
		{
			if (m_LoadingMessageText != null)
			{
				m_LoadingMessageText.text = text;
			}
		}

#endregion // UI
    }
}