using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace StackMoney
{
    public class scBuildInfo : MonoBehaviour
    {
        [SerializeField]
        public scAptSettings scAptSettings;

        [SerializeField]
        scObjSettings _set;

        [SerializeField]
        TMP_Text _name;

        [SerializeField]
        TMP_Text _price;

        [SerializeField]
        Transform _parent;

        int _plateMoneyCount;
        int offset = 0;

        bool isCheck = true;
        private void Awake()
        {
            GetInfo();
        }

        public void GetInfo()
        {
            if (!scAptSettings.buildIsBought)
            {
                _name.text = scAptSettings.name;
                _price.text = scAptSettings.buildGivedMoney + "\n" + "Buy $ " + scAptSettings.buildPrice.ToString();
                scAptSettings.buildMaterial.color = Color.black;

            }

            if (scAptSettings.buildIsBought)
            {
                _name.text = scAptSettings.name + " is Bought!";
                _price.text = scAptSettings.buildEarnMoneyCount + " / " + scAptSettings.buildEarnMoneySec + " s";
                scAptSettings.buildMaterial.color = Color.white;
                StartCoroutine(BuildMoneySpawner(_set.objMoney));
            }
        }
        private void LateUpdate()
        {

            if (!isCheck && scAptSettings.buildIsBought)
            {
                StartCoroutine(BuildMoneySpawner(_set.objMoney));
                isCheck = true;
            }
        }
        IEnumerator BuildMoneySpawner(GameObject obj)
        {
            yield return new WaitForSeconds(scAptSettings.buildEarnMoneySec);

            while (_plateMoneyCount < scAptSettings.buildEarnMoneyCount / 10 && isCheck)
            {
                GameObject tmpObj = Instantiate(obj);
                tmpObj.transform.parent = _parent.transform;
                tmpObj.GetComponent<BoxCollider>().isTrigger = true;
                tmpObj.gameObject.tag = "Money";
                tmpObj.transform.localPosition = new Vector3(0, transform.localPosition.y + offset, 0);
                _plateMoneyCount++;
                offset += 40;
                yield return new WaitForSeconds(1);
            }
            StopCoroutine(BuildMoneySpawner(_set.objMoney));
            isCheck = false;
            _plateMoneyCount = 0;
            offset = 0;
        }


    }
}
