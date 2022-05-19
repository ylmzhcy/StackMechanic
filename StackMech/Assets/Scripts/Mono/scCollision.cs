using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StackMoney
{
    public class scCollision : MonoBehaviour
    {
        Vector3 _firstPos = new Vector3(0, 1, 0.65f);
        Vector3 _offPos = new Vector3(0, 0.33f, 0);

        [SerializeField]
        Transform _parent;

        public List<GameObject> moneys = new List<GameObject>();

        [SerializeField]
        scPlayerInfo playerInfo;

        [SerializeField]
        TMP_Text txtMoney;

        [SerializeField]
        scMoneySpawner _scMoneySpawner;

        [SerializeField]
        AudioSource _audioSource;

        [SerializeField]
        GameObject _ShopPanel;

        private void Awake()
        {
            WriteMoneyPanel();
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Money")
            {
                if (moneys.Count <= 0)
                {
                    other.gameObject.transform.parent = _parent;
                    other.gameObject.transform.localPosition = _firstPos;
                    moneys.Add(other.gameObject);
                    other.gameObject.tag = "Untagged";
                    AddMoney();
                }
                else
                {
                    other.gameObject.transform.parent = _parent;
                    other.gameObject.transform.localPosition = moneys[moneys.Count - 1].transform.localPosition + _offPos;
                    moneys.Add(other.gameObject);
                    other.gameObject.tag = "Untagged";
                    AddMoney();
                }
            }

            if (other.gameObject.tag == "Build")
            {
                scBuildInfo _info = other.gameObject.GetComponent<scBuildInfo>();

                if (!_info.scAptSettings.buildIsBought)
                {
                    if (playerInfo.totalMoney + _info.scAptSettings.buildGivedMoney < _info.scAptSettings.buildPrice)
                    {
                        _info.scAptSettings.buildGivedMoney += playerInfo.totalMoney;
                        playerInfo.totalMoney = 0;
                        DestroyAllMoney();
                        WriteMoneyPanel();
                        _info.GetInfo();
                    }

                    if (playerInfo.totalMoney >= _info.scAptSettings.buildPrice)
                    {
                        playerInfo.totalMoney -= _info.scAptSettings.buildPrice;
                        WriteMoneyPanel();
                        _info.scAptSettings.buildIsBought = true;
                        _info.scAptSettings.buildGivedMoney = _info.scAptSettings.buildPrice;
                        _info.GetInfo();
                    }

                    if (playerInfo.totalMoney + _info.scAptSettings.buildGivedMoney >= _info.scAptSettings.buildPrice)
                    {
                        int tmp = _info.scAptSettings.buildPrice - _info.scAptSettings.buildGivedMoney;
                        playerInfo.totalMoney -= tmp;
                        _info.scAptSettings.buildIsBought = true;
                        _info.scAptSettings.buildGivedMoney = _info.scAptSettings.buildPrice;
                        WriteMoneyPanel();
                        _info.GetInfo();
                        int countMoney = tmp / 10;
                        if (moneys.Count != 0)
                        {
                            DestroyMoney(countMoney);
                        }
                    }
                }
            }
        }
        private void WriteMoneyPanel()
        {
            txtMoney.text = "$ " + playerInfo.totalMoney.ToString();
        }
        private void AddMoney()
        {
            playerInfo.totalMoney += 10;
            _audioSource.Play();
            txtMoney.text = "$ " + playerInfo.totalMoney.ToString();
            _scMoneySpawner._moneyCount--;
        }

        private void DestroyMoney(int destroyCount)
        {
            int tmp = moneys.Count;
            for (int i = moneys.Count - 1; i >= tmp - destroyCount; i--)
            {
                Destroy(moneys[i]);
                moneys.Remove(moneys[i]);
            }
        }

        private void DestroyAllMoney()
        {
            foreach (var item in moneys)
            {
                Destroy(item);
            }
            moneys.Clear();
        }

    }
}