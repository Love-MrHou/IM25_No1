using UnityEngine;

public class CameraCircularMovement: MonoBehaviour
{
    [SerializeField] private GameObject target;//Camera�n���V������
    [SerializeField] private float speed;//�۾���¶���ʪ��t��
    private Vector3 cameraPosition;//�۾��n���ʪ���m
    private float number;
    private float radius;//���ʪ��b�|

    private void Start()
    {
        //�]�w�ny�b����l��m
        cameraPosition.y = transform.position.y;
        transform.position = cameraPosition;

        //�p���e��v���M�ؼЪ��󪺥b�|
        radius = Vector3.Distance(target.transform.position, transform.position);
    }


    private void Update()
    {
        number += Time.deltaTime * speed * 0.1f;  //�p��ó]�w�s��x�My�b��m
        //�t�ƬO���ɰw����A���ƬO�f�ɰw����
        cameraPosition.x = radius * Mathf.Cos(number);
        cameraPosition.z = radius * Mathf.Sin(number);
        transform.position = cameraPosition;

        //�Ϭ۾��û�����ۥؼЪ���
        transform.LookAt(target.transform.position);
    }
}