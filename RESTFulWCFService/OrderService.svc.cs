using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.Collections;
namespace RESTFulWCFService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "OrderService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione OrderService.svc o OrderService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class OrderService : IOrderService
    {
        public OrderContract GetOrderDetails(string OrderID)
        {
            OrderContract order = new OrderContract();

            try
            {
                XDocument doc = XDocument.Load("D:\\Servicio Web\\Orders.xml");

                IEnumerable<XElement> orders =
                    (from result in doc.Descendants("DocumentElement")
                        .Descendants("Orders")
                     where result.Element("OrderID").Value == OrderID.ToString()
                     select result);

                order.OrderID = orders.ElementAt(0)
                                            .Element("OrderID").Value;
                order.OrderDate = orders.ElementAt(0)
                                            .Element("OrderDate").Value;
                order.ShippedDate = orders.ElementAt(0)
                                            .Element("ShippedDate").Value;
                order.ShipCountry = orders.ElementAt(0)
                                            .Element("ShipCountry").Value;
                order.OrderTotal = orders.ElementAt(0)
                                            .Element("OrderTotal").Value;
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return order;
        }

        public string GetOrderTotal(string OrderID)
        {
            string orderTotal = string.Empty;

            try
            {
                XDocument doc = XDocument.Load("D:\\Servicio Web\\Orders.xml");

                orderTotal =
                (from result in doc.Descendants("DocumentElement")
                .Descendants("Orders")
                 where result.Element("OrderID").Value == OrderID.ToString()
                 select result.Element("OrderTotal").Value)
                .FirstOrDefault<string>();

            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return orderTotal;
        }

        public bool PlaceOrder(OrderContract order)
        {
            try
            {
                XDocument doc = XDocument.Load("D:\\Servicio Web\\Orders.xml");

                doc.Element("DocumentElement").Add(
                        new XElement("Products",
                        new XElement("OrderID", order.OrderID),
                        new XElement("OrderDate", order.OrderDate),
                        new XElement("ShippedDate", order.ShippedDate),
                        new XElement("ShipCountry", order.ShipCountry),
                        new XElement("OrderTotal", order.OrderTotal)));

                doc.Save("D:\\Servicio Web\\Orders.xml");
            }
            catch (Exception ex)
            {
                throw new FaultException<string>
                        (ex.Message);
            }
            return true;
        }
    }
}
