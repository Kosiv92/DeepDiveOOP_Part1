using System;
using CIM = DeepDiveOOP_Part1.ConsoleInterfaceMethods;

namespace DeepDiveOOP_Part1
{
    class Program
    {
        public static void Main()
        {
            ApplicationUser user = new Consultant(AccessRightments.GetConsultantAccessRightments());

            ClientManager clientManager = new ClientManager(user);
                                    
            IUserInterface userConsole = new ConsoleInterfaceMethods(clientManager);
                        
            clientManager.Repository = userConsole.SetRepository();

            clientManager.LoadClients();

            userConsole.ShomMainMenu(user);                        
        }

        
    }

}













