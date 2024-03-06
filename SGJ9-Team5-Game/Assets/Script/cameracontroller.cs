using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{

    public float sensitivity = 300f; // マウス感度
    public Transform playerBody; // プレイヤーのTransform
    float xRotation = 0f;
    float yRotation = 0f;
    public float smoothSpeed = 0.125f; // カメラ移動のスムーズ化に使う変数
    public Vector3 offset; // カメラと対象の距離のオフセット


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // 上下方向の視点の回転
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 上下の視点の回転を制限する
        yRotation -= mouseX;


        // カメラの上下左右の回転
        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseX); 
        
// カメラをプレイヤーの体に追従させる
        transform.position = playerBody.position;
        Vector3 cameraPosition = playerBody.position + Vector3.up;
        transform.position = cameraPosition;
    }
}
