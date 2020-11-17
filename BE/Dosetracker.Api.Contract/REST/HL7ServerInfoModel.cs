namespace Cloud.HL7.Api.Contract
{
    public class ServerInfoModel
    {
        public ServerInfoModel()
        {

        }
        public ServerInfoModel(string iPAddress, int port)
        {
            IPAddress = iPAddress;
            Port = port;
        }

        public string IPAddress { get; set; }
        public int Port { get; set; }
    }
}
