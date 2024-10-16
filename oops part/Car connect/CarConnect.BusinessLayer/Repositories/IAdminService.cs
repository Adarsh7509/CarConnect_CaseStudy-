using CarConnect.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Repositories
{
    public interface IAdminService
    {
        Admin GetAdminById(int adminId);
        Admin GetAdminByUsername(string username);
        void RegisterAdmin(Admin adminData);
        void UpdateAdmin(Admin adminData);
        void DeleteAdmin(int adminId);
    }
}
