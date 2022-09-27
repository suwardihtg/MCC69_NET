using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.Services;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class UserRepository //: IUser
    {
        MyContext MyContext;
        public UserRepository(MyContext MyContext)
        {
            this.MyContext = MyContext;
        }
        public List<User> Get()
        {
            var data = MyContext.Users.ToList();
            return data;
        }
        public Employees GetEmployee(string email)
        {
            var checkEmployee = MyContext.Employees.SingleOrDefault(user => user.Email.Equals(email));
            return checkEmployee;
        }
        /*public User GetUserByEmail(string email)
        {
            var getEmployee = MyContext.Employees.SingleOrDefault(e => e.Email.Equals(email));
            if (getEmployee != null)
            {
                var getUser = MyContext.Users.Find(getEmployee.Id);
                return getUser;
            }
            return null;
        }*/
        public User Login(string email, string password)
        {
            var checkEmployee = GetEmployee(email);
            if (checkEmployee != null)
            {
                var checkUser = Get(checkEmployee.Id);
                if (checkUser != null)
                {
                    if (checkUser.Password == password)
                        return checkUser;
                }
            }
            return null;
        }

        public User GetByName(string UserName)
        {
            var data = MyContext.Users.SingleOrDefault(options => options.UserName.Equals(UserName));

            return data;
            
        }
        public User Get(int id)
        {
            var checkUsername = MyContext.Users.Find(id);
            return checkUsername;
        }

        public int Post(Register register)
        {
            /* if (MyContext.Users.Any(option => option.UserName == user.UserName))
                 return 0;
             MyContext.Users.Add(user);
             var result = MyContext.SaveChanges();
             return result;*/
            MyContext.Employees.Add(
                 new Employees
                 {
                     FirstName = register.FirstName,
                     LastName = register.LastName,
                     Email = register.Email,
                     PhoneNumber = register.PhoneNumber,
                     HireDate = register.HireDate,
                     Salary = register.Salary,
                     Job_Id = register.Job_Id,
                     Manager_Id = register.Manager_Id,
                     Department_Id = register.Department_Id
                 });
            int resultAddingEmployee = MyContext.SaveChanges();
            if (resultAddingEmployee > 0)
            {
                var currentUser = MyContext.Employees.SingleOrDefault(_e => _e.Email.Equals(register.Email));

                var passwordHash = Bycript.HashPassword(register.Password);
                MyContext.Users.Add(
                    new User
                    {
                        Id = currentUser.Id,
                        UserName = register.Username,
                        Password = passwordHash
                       // Password = register.Password
                    }
                );
                int resultAddingUser = MyContext.SaveChanges();
                if (resultAddingUser > 0)
                {

                    MyContext.UserRoles.Add(new UserRole { User_Id = currentUser.Id, Role_Id = 2 });
                    int result = MyContext.SaveChanges();
                    return result;
                }
            }

            return 0;
        }

        public int Put(User user)
        {
            var data = MyContext.Users.Find(user.Id);
            if (data == null)
                return 0;

            user.UserName = user.UserName;
            user.Password = user.Password;
            var result = MyContext.SaveChanges();
            return result;
        }
        public User GetUserByEmail(string email)
        {
            var getEmployee = MyContext.Employees.SingleOrDefault(e => e.Email.Equals(email));
            if (getEmployee != null)
            {
                var getUser = MyContext.Users.Find(getEmployee.Id);
                return getUser;
            }
            return null;
        }
        public int ForgetPassword(string email, string Password)
        {
            //var checkUsername = MyContext.Users.SingleOrDefault(user => user.UserName.Equals(UserName));
            var chekEmail = GetUserByEmail(email);
            if (chekEmail != null)
            {
                chekEmail.Password = Password;
                int result = MyContext.SaveChanges();
                return result;
            }
            return 0;
        }
        public int ChangePassword(string email, string oldPassword, string newPassword)
        {
            var checkEmail = MyContext.Employees.SingleOrDefault(_employee => _employee.Email.Equals(email));
            if (checkEmail != null)
            {
                var checkUser = MyContext.Users.Find(checkEmail.Id);
                if (checkUser != null)
                {
                    if (oldPassword == checkUser.Password)
                    {
                        checkUser.Password = newPassword;
                        int result = MyContext.SaveChanges();
                        return result;
                    }
                }
            }
            return 0;
        }
        public string GetRoleById(int id)
        {
            /*var user = MyContext.UserRoles.FirstOrDefault(x => x.User_Id == UserId);

            return user;*/
            var user = MyContext.Users.Find(id);
            UserRole[] userRole = MyContext.UserRoles.Where(x => x.User_Id.Equals(id)).ToArray();
            Role role;
            if (userRole.Length > 1)
            {
                role = MyContext.Roles.Find(1);
            }
            role = MyContext.Roles.Find(userRole[0].Role_Id);
            return role.Name;

        }
    }
}
