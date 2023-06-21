using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;
namespace RESTFulWCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IOrderService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetOrderTotal/{OrderID}",
                ResponseFormat = WebMessageFormat.Json)]
        string GetOrderTotal(string OrderID);

        [OperationContract]
        [WebGet(UriTemplate = "/GetOrderDetails/{OrderID}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        OrderContract GetOrderDetails(string OrderID);

        [OperationContract]
        [WebInvoke(UriTemplate = "/PlaceOrder",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool PlaceOrder(OrderContract order);
    }
}
