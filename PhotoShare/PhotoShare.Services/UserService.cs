using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class UserService
    {
        public void RegisterUser(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsUserExisting(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public User GetUserByUsername(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username);
            }
        }

        public void UpdateUser(User u)
        {
            using (var context = new PhotoShareContext())
            {
                User user = context.Users
                    .Include("BornTown")
                    .Include("CurrentTown")
                    .SingleOrDefault(x => x.Id == u.Id);
                context.SaveChanges();
                if (user != null)
                {
                    if (u.Password != user.Password)
                    {
                        user.Password = u.Password;
                    }
                    if (u.BornTown != null &&
                        user.BornTown == null || u.BornTown.Id != user.BornTown.Id)
                    {
                        user.BornTown = context.Towns.Find(u.BornTown.Id);
                    }
                    if (u.CurrentTown != null &&
                      user.CurrentTown == null || u.CurrentTown.Id != user.CurrentTown.Id)
                    {
                        user.CurrentTown = context.Towns.Find(u.CurrentTown.Id);
                    }
                }

            }
        }

        public bool IsUserDeleted(string username)
        {
            using (var context = new PhotoShareContext())
            {
                bool? isDeleted = context.Users.FirstOrDefault(u => u.Username == username).IsDeleted;
                if (isDeleted == null)
                {
                    return false;
                }
                return isDeleted.Value;
            }
        }

        public void DeleteUser(string username)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.FirstOrDefault(u => u.Username == username).IsDeleted = true;
                context.SaveChanges();
            }
        }

        public void MakeFriendship(string user1Name, string user2Name)
        {

            using (var context = new PhotoShareContext())
            {
                if (user1Name != user2Name)
                {
                    var user1 = context.Users.SingleOrDefault(u => u.Username == user1Name);
                    var user2 = context.Users.SingleOrDefault(u => u.Username == user2Name);
                    user1.Friends.Add(user2);
                    user2.Friends.Add(user1);
                    context.SaveChanges();

                }
            }
        }

        public bool HasFriends(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username).Friends.Count != 0;
            }
        }
        public List<User> ListUsers(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == username).Friends.ToList();
            }
        }
    }
}
