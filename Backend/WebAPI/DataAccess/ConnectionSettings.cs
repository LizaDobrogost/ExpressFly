using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class ConnectionSettings : IConnectionSettings
    {
        private IConfiguration _configuration { get; }
        public string ConnectionString => _configuration[nameof(ConnectionString)];

        public ConnectionSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}