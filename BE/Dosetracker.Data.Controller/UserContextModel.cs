namespace GT.SERVICE
{
    public class UserContextModel
    {
        public UserContextModel(long userIDCurrent)
        {
            UserIDCurrent = userIDCurrent;
        }

        public long UserIDCurrent { get; set; }
    }
}