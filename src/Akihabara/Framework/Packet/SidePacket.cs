using System;
using Akihabara.Core;
using Akihabara.Native.Framework;

namespace Akihabara.Framework.Packet
{
    public class SidePacket : MpResourceHandle
    {
        public SidePacket() : base()
        {
            UnsafeNativeMethods.mp_SidePacket__(out var ptr);
            this.ptr = ptr;
        }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_SidePacket__delete(ptr);
        }

        public int Size => SafeNativeMethods.mp_SidePacket__size(MpPtr);

        // According to homuler's to-do, this should be a Packet.
        // not sure if this is correct but this should do for now.
        // See: https://git.io/JcCig
        public Packet<T> At<T>(string key)
        {
            UnsafeNativeMethods.mp_SidePacket__at__PKc(MpPtr, key, out var packetPtr);

            if (packetPtr == IntPtr.Zero)
                return default(Packet<T>);

            GC.KeepAlive(this);
            return (Packet<T>)Activator.CreateInstance(typeof(Packet<T>), packetPtr, true);
        }

        public void Emplace<T>(string key, Packet<T> packet)
        {
            UnsafeNativeMethods.mp_SidePacket__emplace__PKc_Rp(MpPtr, key, packet.MpPtr);

            packet.Dispose();
            GC.KeepAlive(this);
        }

        public int Erase(string key)
        {
            UnsafeNativeMethods.mp_SidePacket__erase__PKc(MpPtr, key, out var count);

            GC.KeepAlive(this);
            return count;
        }

        public void Clear()
        {
            SafeNativeMethods.mp_SidePacket__clear(MpPtr);
        }

    }
}
