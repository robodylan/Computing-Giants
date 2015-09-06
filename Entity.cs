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
        public Entity(string private_key, string username, string public_key)
        {
            this.privateKey = private_key;
            this.username = username;
            this.publicKey = public_key;
            this.level = 1;
        }
    }
}
