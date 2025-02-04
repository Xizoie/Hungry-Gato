using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Camera _cam1;
    //[SerializeField] private Camera _cam2;

    private Vector3 offset;
    void Start()
    {
        //_cam1 is enabled at start
        _cam1.enabled = true;
        //_cam2.enabled = false;
        offset = new Vector3(0,-1,0);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position - offset;
        //Change();//change camera code
    }
    //private void Change()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && (_cam1.enabled == true))
    //    {
    //        _cam1.enabled = !_cam1.enabled;
    //        _cam2.enabled = true;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Space) && (_cam2.enabled == true))
    //    {
    //        _cam1.enabled = true;
    //        _cam2.enabled = !_cam2.enabled;
    //    }

    //}



}
