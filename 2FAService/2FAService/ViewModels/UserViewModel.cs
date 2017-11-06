using _2FAService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _2FAService.ViewModels
{
    public class UserViewModel
    {
        private static UserViewModel instance;

        private ASCIIEncoding Encoder { get; }
        private readonly Random randomId;
        private readonly Guid Key;
        private HMACSHA512 Hash;

        public List<User> Users { get; }

        UserViewModel() {

            Encoder = new ASCIIEncoding();
            randomId = new Random(10000);
            Key = Guid.NewGuid();
            Hash = new HMACSHA512(Key.ToByteArray());
            Users = GenerateUsers();
        }

        public static UserViewModel Instance
        {

            get
            {

                if (instance == null) { instance = new UserViewModel(); }

                return instance;
            }
        }

        public User GetUserByUserNameAndPassword(string userName, string password)
        {

            if (Users.Any() == false)
            {
                throw new Exception("Nenhum usuário cadastrado");
            }

            var currentUser = Users.Where(user => user.UserName == userName && user.Password == CreatePassword(password)).FirstOrDefault();

            if (currentUser == null) { throw new Exception("Usuário não encontrado"); }

            return currentUser;
        }

        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2");
            }
            return (sbinary);
        }

        private List<User> GenerateUsers()
        {

            return new List<User>() {

                new User() {

                    UserId = randomId.Next(),
                    Nome = "Fulano 1",
                    UserKey = Guid.NewGuid(),
                    SecretKey = CreateSecretKey(),
                    SecretKey256 = CreateSecretKey256(),
                    UserName = "fulano@email.com",
                    Password = CreatePassword("123456"),
                    HasTwoFactor = false
                },

                new User() {

                    UserId = randomId.Next(),
                    Nome = "Fulano 2",
                    UserKey = Guid.NewGuid(),
                    SecretKey = CreateSecretKey(),
                    SecretKey256 = CreateSecretKey256(),
                    UserName = "fulano2@email.com",
                    Password = CreatePassword("123456"),
                    HasTwoFactor = false
                },

                new User() {

                    UserId = randomId.Next(),
                    Nome = "Fulano 3",
                    UserKey = Guid.NewGuid(),
                    SecretKey = CreateSecretKey(),
                    SecretKey256 = CreateSecretKey256(),
                    UserName = "fulano3@email.com",
                    Password = CreatePassword("123456"),
                    HasTwoFactor = true
                },

                new User() {

                    UserId = randomId.Next(),
                    Nome = "Fulano 4",
                    UserKey = Guid.NewGuid(),
                    SecretKey = CreateSecretKey(),
                    SecretKey256 = CreateSecretKey256(),
                    UserName = "fulano4@email.com",
                    Password = CreatePassword("123456"),
                    HasTwoFactor = true
                }
            };
        }

        private string CreatePassword(string wordForPassword)
        {
            //var hash = new HMACSHA512(Key.ToByteArray());

            return ByteToString(Hash.ComputeHash(Encoder.GetBytes(wordForPassword)));
        }

        private string CreateSecretKey()
        {
            var hash = new HMACSHA1(Key.ToByteArray());

            return ByteToString(hash.ComputeHash(Guid.NewGuid().ToByteArray()));
        }

        private string CreateSecretKey256()
        {
            var hash = new HMACSHA256(Key.ToByteArray());

            return ByteToString(hash.ComputeHash(Guid.NewGuid().ToByteArray()));
        }
    }
}