using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

namespace Net
{
    public class MatchMaker : MonoBehaviour
    {
        /// <summary>
        /// マッチのプレイヤーの最大人数
        /// </summary>
        private const uint MATCH_SIZE = 5;

        /// <summary>
        /// リストのマッチの最大数
        /// </summary>
        private const int RESULT_PAGE_SIZE = 10;


        /// <summary>
        /// ロード中のテキスト変更イベント
        /// </summary>
        public event Action<string> onShowLoadingText;



#region ルーム作成

        public void CreateInternetMatch(MatchRoomInfo info, Action onSuccess, Action onFailed)
        {
            NetworkManager.singleton.StartMatchMaker();

            var matchName = info.roomName;
            var matchAdvertise = true;         //NetworkMatch.ListMatchesで帰ってくるList<MatchInfoSnapshot>に、このマッチを含めるかどうか
            var matchPassword = info.password; //マッチのパスワード
            var publicClientAddress = "";      //クライアントがインターネット経由で直接接続するためのネットワークアドレス
            var privateClientAddress = "";     //クライアントが LAN 経由で直接接続するためのネットワークアドレス
            var eloScoreForMatch = 0;          //いわゆるスキルレート。全クライアントが0だとランダムになる
            var requestDomain = 0;             //クライアントバージョンを区別するための番号

            NetworkManager.singleton.matchMaker.CreateMatch(matchName, MATCH_SIZE, matchAdvertise, matchPassword, publicClientAddress, privateClientAddress, eloScoreForMatch, requestDomain, 
            (success, extendedInfo, matchInfo) => {
                if (success)
                {
                    MatchInfo hostInfo = matchInfo;
                    NetworkServer.Listen(hostInfo, 9000);

                    NetworkManager.singleton.StartHost(hostInfo);

                    onShowLoadingText.SafeInvoke("ルーム作成に成功しました");
                    onSuccess.SafeInvoke();
                }
                else
                {
                    onShowLoadingText.SafeInvoke("ルーム作成に失敗しました");
                    onFailed.SafeInvoke();
                }
            });
        }

#endregion // ルーム作成


#region ルーム入室

        public void EnterInternetMatch(MatchRoomInfo info, Action onSuccess, Action onFailed)
        {
            NetworkManager.singleton.StartMatchMaker();

            var startPageNumber = 0;                         //リストし始めるページ
            var matchNameFilter = info.roomName;             //*<matchNameFilter>*に該当するマッチが検索される
            var filterOutPrivateMatchesFromResults = true;   //プライベートマッチを検索結果に含めるかどうか
            var eloScoreTarget = 0;                          //検索するときのスキルレート
            var requestDomain = 0;                           //クライアントバージョンを区別するための番号

            NetworkManager.singleton.matchMaker.ListMatches(startPageNumber, RESULT_PAGE_SIZE, matchNameFilter, filterOutPrivateMatchesFromResults, eloScoreTarget, requestDomain, 
            (success, extendedInfo, matches) => {
                if (success)
                {
                    if (matches.Count == 0)
                    {
                        onShowLoadingText.SafeInvoke("該当するルームがありませんでした");
                        onFailed.SafeInvoke();
                    }
                    else
                    {
                        foreach (var match in matches)
                        {
                            Debug.LogFormat("roomName: {0}", match.name);
                        }
                        var earliestCreatedMatch = matches.Find(v => v.currentSize != v.maxSize);
                        JoinMatch(earliestCreatedMatch.networkId, info, onSuccess, onFailed);
                    }
                }
                else
                {
                    onShowLoadingText.SafeInvoke("ルームリストの取得に失敗しました");
                    onFailed.SafeInvoke();
                }
            });
        }


        private void JoinMatch(UnityEngine.Networking.Types.NetworkID networkId, MatchRoomInfo roomInfo, Action onSuccess, Action onFailed)
        {
            NetworkManager.singleton.matchMaker.JoinMatch(networkId, roomInfo.password, "", "", 0, 0, 
            (success, extendedInfo, match) => {
                if (success)
                {
                    MatchInfo hostInfo = match;
                    NetworkManager.singleton.StartClient(hostInfo);
                    onShowLoadingText.SafeInvoke("ルーム参加に成功しました");
                    onSuccess.SafeInvoke();
                }
                else
                {
                    onShowLoadingText.SafeInvoke("ルームに参加できませんでした");
                    onFailed.SafeInvoke();
                }
            });
        }

#endregion // ルーム入室
    }
}