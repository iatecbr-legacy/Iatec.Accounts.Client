using Iatec.Accounts.Client;
using Iatec.Accounts.Client.Api;
using Iatec.Accounts.Client.Model;
using IdentityModel.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TesteCliente
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string CLIENT_ID = "00000000000000000000000000000000";
            const string CLIENT_SECRET = "secretsecretsecretsecretsecretsecretsecretsecret";

            var discoveryClient = new DiscoveryClient("https://login-dev.sdasystems.org");
            var discovery = discoveryClient.GetAsync().Result;

            var tokenClient = new TokenClient(discovery.TokenEndpoint, CLIENT_ID, CLIENT_SECRET);
            var tokens = tokenClient.RequestClientCredentialsAsync("scope").Result;
            // ---------------------------------------------------------------------------------------------------------- //
            var apiConfig = new Iatec.Accounts.Client.Configuration()
            {
                AccessToken = tokens.AccessToken,
                BasePath = "https://ws-accounts-dev.sdasystems.org",
            };

            var user = CreateUserTest(apiConfig);
            ResetPasswordByEmailTest(apiConfig, user.Email);
            ResetPasswordByUsernameTest(apiConfig, user.Username);

            Console.WriteLine(user.ToString());

            var newUser = new UserInsertModel()
            {
                Email = "william.quadros123@yopmail.com",
                FirstName = "Azeite",
                LastName = "Mouras",
                Password = "teste123",
                UserName = "azeite.adems",
            };



            var user1 = UpdateUserByIdTest(apiConfig, user.Id, newUser);

            Console.WriteLine(user1.ToString());

            user1.Username = "adems.azeite";

            var user2 = UpdateUserByUsernameTest(apiConfig, user1.Username, newUser);

            Console.WriteLine(user2.ToString());

            user2.Email = "azeite.adems17@yopmail.com";

            var user3 = UpdateUserByEmailTest(apiConfig, user2.Email, newUser);

            Console.WriteLine(user3?.ToString());

            var a = GetUserByEmailTest(apiConfig, user?.Email);
            Console.WriteLine(a?.ToString() ?? "Not Found!");

            //ChagePasswordByIdTest(apiConfig, user.Id);
            //if (user != null && false)
            //{
            //    var a = GetUserByEmailTest(apiConfig, user.Email);
            //    var b = GetUserByIdTest(apiConfig, user.Id);
            //    var c = GetUserByUsernameTest(apiConfig, user.UserName);

            //    Console.WriteLine(c.ToString());
            //}
            //var userList = GetUsersByFilter(apiConfig, "william");
            //foreach (var item in userList.Items)
            //{
            //    Console.WriteLine("*");
            //    Console.WriteLine(item.ToString());
            //    Console.WriteLine("*");
            //}

            Console.WriteLine("-- END --");
            Console.ReadLine();
        }

        #region UPDATE

        private static void ChagePasswordByIdTest(Iatec.Accounts.Client.Configuration apiConfig, Guid id)
        {
            try
            {
                var api = new UserApi(apiConfig);

                api.ChangeUserPasswordById(id, "admin");
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static void ResetPasswordByUsernameTest(Iatec.Accounts.Client.Configuration apiConfig, string username)
        {
            try
            {
                var api = new UserApi(apiConfig);

                api.ResetPasswordByUsername(username, "admin");
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static void ResetPasswordByEmailTest(Iatec.Accounts.Client.Configuration apiConfig, string email)
        {
            try
            {
                var api = new UserApi(apiConfig);

                api.ResetPasswordByEmail(email, "admin");
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static UserModel UpdateUserByIdTest(Iatec.Accounts.Client.Configuration apiConfig, Guid id, UserInsertModel user)
        {
            try
            {
                var api = new UserApi(apiConfig);

                return api.UpdateUserById(id, user);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static UserModel UpdateUserByUsernameTest(Iatec.Accounts.Client.Configuration apiConfig, string username, UserInsertModel user)
        {
            try
            {
                var api = new UserApi(apiConfig);

                return api.UpdateUserByUsername(username, user);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static UserModel UpdateUserByEmailTest(Iatec.Accounts.Client.Configuration apiConfig, string email, UserInsertModel user)
        {
            try
            {
                var api = new UserApi(apiConfig);

                return api.UpdateUserByEmail(email, user);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GET

        private static UserModel GetUserByUsernameTest(Iatec.Accounts.Client.Configuration apiConfig, string username)
        {
            try
            {
                var api = new UserApi(apiConfig);

                return api.GetUserByUsername(username);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static UserModel GetUserByEmailTest(Iatec.Accounts.Client.Configuration apiConfig, string email)
        {
            try
            {
                var api = new UserApi(apiConfig);

                return api.GetUserByEmail(email);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static UserModel GetUserByIdTest(Iatec.Accounts.Client.Configuration apiConfig, Guid userId)
        {
            try
            {
                var api = new UserApi(apiConfig);

                return api.GetUserById(userId);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        private static PagedResponse<UserModel> GetUsersByFilter(Iatec.Accounts.Client.Configuration apiConfig, string filter)
        {
            try
            {
                var api = new UserApi(apiConfig);

                return api.GetPagerUserByFilter(10, 0, filter);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        #endregion

        private static UserModel CreateUserTest(Iatec.Accounts.Client.Configuration apiConfig)
        {
            try
            {
                var api = new UserApi(apiConfig);
                return api.CreateUser(new UserInsertModel
                {
                    FirstName = "William",
                    LastName = "Moura",
                    Password = "adems23",
                    Email = "william.moura23@yopmail.com",
                    UserName = "william.moura23",
                });
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }
    }
}