
using GT.SERVICE;

namespace GT.SERVICE
{
    public class BussinessContext : IBussinessContext
    {
       // private PermissionViewModel _persmission;

        public BussinessContext(UserContextModel userInfo)
        {
            UserInfo = userInfo;
        }
        public UserContextModel UserInfo { get; set; }
    

        //public PermissionViewModel Permission
        //{
        //    get
        //    {
        //        if (_persmission == null)
        //        {
        //            var _Workspace = WorkspaceFactory.Create(true);
        //            var uc = new UserRepository(_Workspace);
        //            if (this.UserInfo.isFirma)
        //            {
        //                _persmission = uc.GetPermissionListByUserID(this.UserInfo.FirmaIDCurrent.Value,false);
        //            }
        //            else
        //            {
        //                _persmission = uc.GetPermissionListByUserID(this.UserInfo.UserIDCurrent.Value,true);
        //            }
        //        }
        //        return _persmission;
        //    }
        //    set => _persmission = value;
        //}
    }
}