using UnityEngine;

public class Play3DSound : MonoBehaviour
{
    private GameObject m_MainCamera = null;

    private Vector3 m_MiddlePointInTrack;

    private Vector3 m_Direction;

    private uint m_PlayingID = 0;

    private float m_MaxDistance = 100;

    private void Awake()
    {
        //初始化坐标。
        m_MainCamera = GameObject.Find("Main Camera");
        m_MiddlePointInTrack = new Vector3(m_MainCamera.transform.position.x, m_MainCamera.transform.position.y, m_MainCamera.transform.position.z + 2);
        Vector3 tempPos = new Vector3(m_MiddlePointInTrack.x, m_MiddlePointInTrack.y, m_MiddlePointInTrack.z);
        tempPos.x = 0;
        transform.position = tempPos;
    }

    void Start()
    {
        //右侧移动。
        m_Direction.x = 1;
        m_Direction.y = 0;
        m_Direction.z = 0;

        //添加音频发声对象。
        this.gameObject.AddComponent<AkGameObj>();
    }

    void Update()
    {
        if (m_PlayingID == 0)
            m_PlayingID = AkSoundEngine.PostEvent("Play_Shot_Gun", this.gameObject);

        float distance = Vector3.Distance(transform.position, m_MiddlePointInTrack);

        if (distance > m_MaxDistance)
            //超过衰减距离反向移动。
            m_Direction = -m_Direction;

        transform.Translate(m_Direction * 10 * Time.deltaTime, Space.World);
    }
}
