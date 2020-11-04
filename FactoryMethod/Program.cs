using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var roles = new List<Role> { new AdminRole(), new EditorRole() };

            foreach (var role in roles)
            {
                Console.WriteLine(role + "----");
                foreach (var item in role.Permissions)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }

    public abstract class Role
    {
        public Role()
        {
            this.CreatePermissions();
        }

        public abstract void CreatePermissions();

        public List<Permission> Permissions { get; protected set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }

    }

    public class AdminRole : Role
    {
        public override void CreatePermissions()
        {
            Permissions = new List<Permission>
            {
                new CreateUser(),
                new RemoveUser()
            };
        }
    }

    public class EditorRole : Role
    {
        public override void CreatePermissions()
        {
            Permissions = new List<Permission>
            {
                new UpdateUser()
            };
        }
    }


    public abstract class Permission
    {

    }

    public class RemoveUser : Permission
    {

    }
    public class CreateUser : Permission
    {

    }

    public class UpdateUser : Permission
    {

    }
    public class GetUser : Permission
    {

    }


}
