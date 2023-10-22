using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GenesisCreationTask {

    public class CammeraController : MonoBehaviour
    {
        PlayerInput _playerInput;
        
        [SerializeField] float _camRotaionSpeed = 50;

        float rotationY = 0;
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            rotationY -= _playerInput.look.y * _camRotaionSpeed;
            //limit cam rotation
            rotationY = Mathf.Clamp(rotationY, -80,80);
            Camera.main.transform.localRotation = Quaternion.Euler(rotationY,0,0);
        }


    }
}