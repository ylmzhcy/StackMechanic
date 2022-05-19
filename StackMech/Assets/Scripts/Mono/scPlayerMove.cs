using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackMoney
{
    public class scPlayerMove : MonoBehaviour
    {
        [SerializeField]
        scObjSettings set;

        [SerializeField]
        Animator _animController;

        Camera _cam;

        private void Awake()
        {
            _cam = Camera.main;
        }

        void FixedUpdate()
        {
            if (Input.GetButton("Fire1"))
            {
                MoveChar();
                _animController.SetBool("isRunning", true);
            }
            else
            {
                _animController.SetBool("isRunning", false);
            }
        }

        private void MoveChar()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = _cam.transform.position.z;

            Ray ray = _cam.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Vector3 hitvector = hit.point;
                hitvector.y = transform.position.y;

                transform.position = Vector3.MoveTowards(transform.position, hitvector, 10 * Time.deltaTime);
                transform.LookAt(hitvector);
            }
        }


    }
}