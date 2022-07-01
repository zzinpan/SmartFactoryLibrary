using UnityEngine;
using System.Runtime.InteropServices;

public class SmartFactory : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void load( string id);

    private string id;

    // Start is called before the first frame update
    void Start()
    {
        
        System.Random random = new System.Random();
        double dobleValue = random.NextDouble();
        string strihgValue = dobleValue.ToString();
        string id = strihgValue.Replace( ".", "" );
        this.id = id;
        
        load( this.id );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
