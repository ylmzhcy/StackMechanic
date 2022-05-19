using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StackMoney
{
    [CreateAssetMenu(menuName = "StackMech/PlayerInfo")]
    public class scPlayerInfo : ScriptableObject
    {
        [SerializeField]
        int _totalMoney;

        public int totalMoney { get { return _totalMoney; } set { _totalMoney = value; } }

    }
}
