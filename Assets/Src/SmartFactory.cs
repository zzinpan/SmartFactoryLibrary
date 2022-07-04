using UnityEngine;
using System.Runtime.InteropServices;

public class SmartFactory : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void completeSetEventKey( string responseJson );

    private string eventKey;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEventKey( string eventKey ){

        this.eventKey = eventKey;

        Response response = new Response( this.eventKey, Response.ResultCode.Success, null );
        SmartFactory.completeSetEventKey( response.toJsonString() );

    }

    // public void addBox( string boxJson ){

    //     {
    //         scale: {
    //             x: 1000, y: 1000, z: 1000
    //         },
    //         position: {
    //             x: 0, y: 0, z: 0
    //         },
    //         rotation: {
    //             x: 0, y: 0, z: 0
    //         },
    //         material: "red"
    //     }

    // }

}
