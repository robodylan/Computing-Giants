namespace Computing_Giants
{
    class Entity
    {
        public bool isMoving = false;
        public string privateKey;
        public string publicKey;
        public string secretKey;
        public int level;
        public string username;
        public string attackingKey;
        public Entity(string key, string username)
        {
            this.privateKey = key;
            this.username = username;
        }
    }
}
