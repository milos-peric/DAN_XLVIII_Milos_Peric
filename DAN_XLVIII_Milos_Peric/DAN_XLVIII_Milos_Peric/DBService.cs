using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLVIII_Milos_Peric
{
    class DBService
    {
        public List<tblPizza> GetPizzas()
        {
            try
            {
                using (PizzeriaServiceEntities context = new PizzeriaServiceEntities())
                {
                    List<tblPizza> list = new List<tblPizza>();
                    list = (from p in context.tblPizzas select p).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblOrder AddOrder(tblOrder order)
        {
            try
            {
                using (PizzeriaServiceEntities context = new PizzeriaServiceEntities())
                {
                    tblOrder newOrder = new tblOrder();
                    newOrder.CustomerJMBG = order.CustomerJMBG;
                    newOrder.OrderStatus = order.OrderStatus;
                    newOrder.OrderDateTime = order.OrderDateTime;
                    context.tblOrders.Add(newOrder);
                    context.SaveChanges();
                    order.ID = newOrder.ID;
                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPizzaOrder AddPizzaOrder(tblPizzaOrder pizzaOrder)
        {
            try
            {
                using (PizzeriaServiceEntities context = new PizzeriaServiceEntities())
                {
                    tblPizzaOrder newPizzaOrder = new tblPizzaOrder();
                    newPizzaOrder.Amount = pizzaOrder.Amount;
                    newPizzaOrder.OrderID = pizzaOrder.OrderID;
                    newPizzaOrder.PizzaID = pizzaOrder.PizzaID;
                    context.tblPizzaOrders.Add(newPizzaOrder);
                    context.SaveChanges();
                    pizzaOrder.ID = newPizzaOrder.ID;
                    return pizzaOrder;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
