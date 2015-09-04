namespace Computing_Giants
{
    class Entity
    {
        public bool isMoving = false;
        public string key;
        public string secretHash;
        public string level;
        public string username;
        public int attackingKey;
        public Entity(string key, string username)
        {
            this.key = key;
            this.username = username;
        }
    }
}
