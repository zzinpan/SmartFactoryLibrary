using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Response
{
    
    public enum ResultCode
    {
        Success = 200,
        Fail = 500
    };

    public string eventKey;
    public ResultCode resultCode;
    public Object data;

    public Response( string eventKey, ResultCode resultCode, Object data ){

        this.eventKey = eventKey;
        this.resultCode = resultCode;
        this.data = data;

    }

    public string toJsonString(){

        return JsonUtility.ToJson( this );

    }

}
