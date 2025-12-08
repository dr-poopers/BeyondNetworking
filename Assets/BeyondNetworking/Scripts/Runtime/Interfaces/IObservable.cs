using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beyond.Networking
{
    public interface IObservable
    {
        void Serialize();

        void Deserialize();
    }

    public class RpcAttribute : Attribute {
        
    }
}
