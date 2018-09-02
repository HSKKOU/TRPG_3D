using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// キャラクターのロード処理
    /// </summary>
    public class CharacterLoader
    {
        /// <summary>
        /// キャラクターモデルのプレハブ
        /// </summary>
        private const string CHARACTER_PREFAB_FOLDER = "Character/";

        /// <summary>
        /// キャラクターをロード
        /// </summary>
        public static IEnumerator Load(string characterName, Action<Character> onComplete)
        {
            Character characterPrefab = Resources.Load<Character>(CHARACTER_PREFAB_FOLDER + characterName);
            Character character = (Character)GameObject.Instantiate(characterPrefab);
            yield return null;
            onComplete.SafeInvoke(character);
        }
    }
}