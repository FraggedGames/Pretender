using Pretender.Entities.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Pretender.GameEngine
{
    // Int16                    -32,768 -                     32,767
    // UInt16                         0 -                     65,535
    // Int32             -2,147,483,648 -              2,147,483,647
    // UInt32                         0 -              4,294,967,295
    // Int64 -9,223,372,036,854,775,808 -  9,223,372,036,854,775,807
    // UInt64                         0 - 18,446,744,073,709,551,615

    public interface IGameObject : IDisposable
    {
        Int32 ID { get; set; }
        IMap Map { get; set; }
        Vector4 Position { get; set; }
        Vector4 Orientation { get; set; }

        Task Update(Double elapsed);
    }

    public interface IMap
    {
        Int32 ID { get; set; }
    }

    [Flags]
    public enum Class
    {
    }
    [Flags]
    public enum Race
    {
    }
}
