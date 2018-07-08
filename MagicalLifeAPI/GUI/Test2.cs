namespace MagicalLifeAPI.GUI
{
    [ProtoBuf.ProtoContract]
    public abstract class Test2 : MagicalLifeServerShell.Test
    {
        [ProtoBuf.ProtoMember(1)]
        private readonly int b = 4;

        public abstract void ABSTRE();
    }
}