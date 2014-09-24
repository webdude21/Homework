namespace Application.WCF
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using Application.WCF.Models;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsers" in both code and config file together.
    [ServiceContract]
    public interface IUsers
    {
        [WebGet(UriTemplate = "services/users")]
        [OperationContract]
        IEnumerable<UserModel> GetUsers();
    }
}