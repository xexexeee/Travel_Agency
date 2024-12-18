using OnlineStore.Storage.MS_SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Logic.JWT
{
    public interface IJwtPorvider
    {
        public string GenerateToken(Client client);
    }
}
