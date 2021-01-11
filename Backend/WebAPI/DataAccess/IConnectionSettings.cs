using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IConnectionSettings
    {
        public string ConnectionString { get; }
    }
}