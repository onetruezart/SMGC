namespace Input.Core
{
    public interface IInputProvider 
    {
        public bool GetKey(int keyId,int playerId);
        public bool GetKeyDown(int keyId,int playerId);
        public bool GetKeyUp(int keyId,int playerId);

        public float GetAxis(int axisId, int playerId);
    }
}