using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public interface IUserInterface
    {
        public ClientData ChooseField();

        public void ShomMainMenu(ApplicationUser user);

        public void EditField(IClient client, ClientData fieldName);

        public void ShowClientList(List<IClient> list);

        public IRepository SetRepository();
    }
}
