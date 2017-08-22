
using System;
using System.Collections.Generic;
using System.Text;

namespace ePrescription.Settings.Settings
{
    public interface ICustomBinarySerializable
    {
        void Deserialize(byte[] bytes);
        byte[] Serialize();
    }
}