namespace MagicalLifeServerShell
{
    [ProtoBuf.ProtoContract]
    public abstract class Test : MagicalLifeAPI.Universal.Unique
    {
        [ProtoBuf.ProtoMember(1)]
        private int test = 3;

        public abstract void GoTEST();
    }
}