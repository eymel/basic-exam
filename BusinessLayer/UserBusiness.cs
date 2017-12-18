using DataAccessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBusiness
    {
        UnitOfWork _uof;
        public UserBusiness()
        {
            _uof = new UnitOfWork();
        }
        public bool Create(User  user) {
            if (string.IsNullOrWhiteSpace(user.UserName)&&string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("Lütfen Kullanıcı Adı ve Şifre giriniz");
            }
            _uof.UserRepository.Add(user);
            return _uof.ApplyChanges();


        }
        public User Login(User user)
        {
            User _user = _uof.UserRepository.GetAll().Where(x => x.UserName == user.UserName && x.Password == user.Password).SingleOrDefault();
           
           
                return _user;
          
        }

    }
}
