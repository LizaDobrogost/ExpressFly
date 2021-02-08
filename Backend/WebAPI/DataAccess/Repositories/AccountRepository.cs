﻿using System;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IConfiguration _connectionSettings;
        private readonly IAccountUpdatingSettings _accountUpdatingSettings;
        private readonly IFilesUploadingSettings _filesUploadingSettings;


        public AccountRepository(
            IConfiguration connectionSettings,
            IAccountUpdatingSettings accountUpdatingSettings,
            IFilesUploadingSettings filesUploadingSettings
        )
        {
            _connectionSettings = connectionSettings;
            _accountUpdatingSettings = accountUpdatingSettings;
            _filesUploadingSettings = filesUploadingSettings;
        }


        public async Task<bool> CheckDuplicateAsync(AccountEntity account)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            return await db.ExecuteScalarAsync<bool>(
                "CheckAccountDuplicate",
                new { email = account.Email },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<AccountEntity> GetByEmailAsync(string email)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            return await db.QuerySingleOrDefaultAsync<AccountEntity>(
                "GetAccountByEmail",
                new { email = email },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<AccountEntity> CreateAccountAsync(AccountEntity account)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            return await db.QuerySingleOrDefaultAsync<AccountEntity>(
                "CreateAccount",
                new
                {
                    firstName = account.FirstName,
                    secondName = account.SecondName,
                    email = account.Email,
                    passwordHash = account.PasswordHash,
                    salt = account.Salt,
                    role = AccountRole.User
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateNameAsync(int accountId, string firstName, string secondName)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            await db.ExecuteAsync(
                "UpdateAccountName",
                new
                {
                    FirstName = firstName,
                    SecondName = secondName,
                    AccountId = accountId,
                    AvatarUpdatingIntervalInSeconds = _accountUpdatingSettings.AvatarUpdatingInterval.TotalSeconds
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAvatarAsync(int accountId, byte[] avatarByteArray, string fileExtension)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            await db.ExecuteAsync(
                "UpdateAccountAvatar",
                new
                {
                    AccountId = accountId,
                    NameUpdatingIntervalInSeconds = _accountUpdatingSettings.NameUpdatingInterval.TotalSeconds
                },
                commandType: CommandType.StoredProcedure);

            foreach (string extension in _filesUploadingSettings.AllowedExtensions)
            {
                string path = Path.Combine(_filesUploadingSettings.StoragePath, accountId + extension);

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }

            await File.WriteAllBytesAsync(
                Path.Combine(_filesUploadingSettings.StoragePath, accountId + fileExtension),
                avatarByteArray
            );
        }

        public async Task<AccountUpdatesEntity> GetAccountUpdatesAsync(int accountId)
        {
            await using SqlConnection db = new SqlConnection(_connectionSettings.GetConnectionString("AirportDatabase"));

            return await db.QuerySingleOrDefaultAsync<AccountUpdatesEntity>(
                "GetAccountUpdates",
                new {AccountId = accountId},
                commandType: CommandType.StoredProcedure);
        }

        public async Task<string> GetAvatarAsync(int accountId)
        {
            string path = string.Empty;
            foreach (string extension in _filesUploadingSettings.AllowedExtensions)
            {
                path = Path.Combine(_filesUploadingSettings.StoragePath, accountId + extension);

                if (!File.Exists(path))
                {
                    path = string.Empty;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            return Path.GetFileName(path);
        }
    }
}