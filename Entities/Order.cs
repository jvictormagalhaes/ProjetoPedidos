using System;
using System.Collections.Generic;
using System.Text;
using ProjetoPedidos.Entities.Enums;
using ProjetoPedidos.Entities;
using System.Globalization;

    namespace ProjetoPedidos.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Product Product { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public Order(DateTime moment, OrderStatus status, Client client, Product product)
        {
            Moment = moment;
            Status = status;
            Client = client;
            Product = product;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public double Total()
        {
            double total = 0;

            foreach(OrderItem i in Items)
            {
                total += i.SubTotal(i.Quantity, i.Price);
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder txt = new StringBuilder();
            txt.AppendLine(" ");
            txt.AppendLine("ORDER SUMMARY: ");
            txt.Append("Order Moment: ");
            txt.AppendLine(Moment.ToString("(dd/MM/yyyy) HH:mm:ss"));
            txt.Append("Order Status: ");
            txt.Append(Status);
            txt.AppendLine(" ");
            txt.Append("Client: ");
            txt.Append(Client.Name);
            txt.Append(" (");
            txt.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            txt.Append(") - ");
            txt.AppendLine(Client.Email);
            txt.AppendLine("Order Items: ");
            foreach (OrderItem i in Items)
            {
                txt.Append(i.Product.Name);
                txt.Append(", $");
                txt.Append(i.Product.Price);
                txt.Append(",00");
                txt.Append(", Quantity: ");
                txt.Append(i.Quantity);
                txt.Append(", SubTotal: $");
                txt.Append(i.SubTotal(i.Quantity, i.Price));
                txt.Append(",00");
                txt.AppendLine(" ");
            }
            txt.AppendLine(" ");
            txt.Append("Total Price: $");
            txt.Append(Total());
            txt.Append(",00");



            return txt.ToString();
        }
    }
}
