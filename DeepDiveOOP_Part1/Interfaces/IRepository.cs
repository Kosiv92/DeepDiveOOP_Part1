using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public interface IRepository
    {
        public string PathToRepository { get; }

        void Save(List<IClient> clients);

        List<IClient> Load();
    }
}
