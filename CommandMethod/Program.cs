using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            AddOrderCommand addOrderCommand = new AddOrderCommand(new OrderManager());
            UpdateOrderCommand updateOrderCommand = new UpdateOrderCommand(new OrderManager());

            DatabaseCommandRunner databaseCommandRunner = new DatabaseCommandRunner();


            databaseCommandRunner.Runner(addOrderCommand);
            databaseCommandRunner.Runner(updateOrderCommand);

            Console.ReadLine();
        }
    }

    public class OrderManager
    {
        public void AddNewOrder() => Console.WriteLine("Yeni sipariş eklendi.");
        public void UpdateOrder() => Console.WriteLine("Sipariş güncellendi");
    }

    public interface ICommand
    {
        void Run();
    }

    public class AddOrderCommand : ICommand
    {
        private OrderManager _orderManager;

        public AddOrderCommand(OrderManager orderManager)
        {
            this._orderManager = orderManager;
        }

        public void Run()
        {
            _orderManager.AddNewOrder();
        }
    }

    public class UpdateOrderCommand : ICommand
    {
        private OrderManager _orderManager;

        public UpdateOrderCommand(OrderManager orderManager)
        {
            this._orderManager = orderManager;
        }

        public void Run()
        {
            _orderManager.UpdateOrder();
        }
    }

    public class DatabaseCommandRunner
    {
        public void Runner(ICommand command)
        {
            command.Run();
        }
    }
}
