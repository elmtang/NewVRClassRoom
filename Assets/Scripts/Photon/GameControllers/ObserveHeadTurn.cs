using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObserveHeadTurn : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject head;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Vector3 pos = transform.localPosition;
            // stream.Serialize(ref pos);
            stream.SendNext(head.transform.position);
            Debug.Log("I am the local client" + GetComponent<PhotonView>().ViewID);

        }
        else
        {
            head = (GameObject)stream.ReceiveNext();
            Debug.Log("I am the Remote client" + GetComponent<PhotonView>().ViewID);
            //Vector3 pos = Vector3.zero;
            //stream.Serialize(ref pos);  // pos gets filled-in. must be used somewhere
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            //transform.rotation = Camera.main.transform.rotation; <- doesnt work anymore
            //Debug.Log("transform.rotation = " + Camera.main.transform.rotation);
        }
    }
}
