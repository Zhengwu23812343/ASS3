using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private float y;
    //���������ٶȲ���
    private float speedOne = 0f;    //����ʵʱ�ٶ�
    private float speedMax = 120f;  //��������ٶ�
    private float speedMin = -20f;  //������С�ٶ�(��������ٶȣ�
    private float speedUpA = 2f;    //�������ټ��ٶȣ�A�����ƣ�
    private float speedDownS = 4f;  //�������ټ��ٶȣ�S�����ƣ�
    private float speedTend = 0.5f; //�޲���ʵʱ�ٶ�����0ʱ���ٶ�
    private float speedBack = 1f;   //�����������ٶ�

    // Update is called once per frame
    void Update()
    {
        //�������
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //����W�������ٶ�û�ﵽ������ٶ�����
        if (Input.GetKey(KeyCode.W) && speedOne < speedMax)
        {
            speedOne = speedOne + Time.deltaTime * speedUpA;
        }
        //����S�������ٶ�û�ﵽ�㣬���ٶȼ�С
        if (Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedDownS;
        }
        //û��ִ���ٶȲ��������ٶȴ�����С�ٶȣ���������
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedTend;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne < 0f)
        {
            speedOne = speedOne + Time.deltaTime * speedTend;
        }

        //����S�������ٶ�û�дﵽ�����ٶ����ʱ���ҳ������ڿ��Ե���״̬ʱ��������
        if (Input.GetKey(KeyCode.S) && speedOne > speedMin && speedOne<=0)
        {
            speedOne = speedOne - Time.deltaTime * speedBack;
        }

        //���¿ո�������ֹͣ
        if (Input.GetKey(KeyCode.Space) && speedOne != 0)
        {
            speedOne = Mathf.Lerp(speedOne, 0, 0.4f);
            if (speedOne < 5) speedOne = 0;
        }

     

               
        transform.Translate(Vector3.forward * speedOne * Time.deltaTime);
        //ʹ��A��D����������������ת
        if(speedOne>1f||speedOne<-1f)
        {
            y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
            transform.Rotate(0, y, 0);
        }
        
       /* if (transform.eulerAngles.z != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }*/
    }
}
