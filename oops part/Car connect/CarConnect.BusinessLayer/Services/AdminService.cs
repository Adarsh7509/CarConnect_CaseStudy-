using CarConnect.BusinessLayer.Repositories;
using CarConnect.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.BusinessLayer.Services
{
    public class AdminService : IAdminService
    {
        public readonly IAdminRepository adminRepository;

        public AdminService(IAdminRepository adminRepo)
        {
            adminRepository = adminRepo;
        }

        public Admin GetAdminById(int adminId)
        {
            return adminRepository.GetById(adminId);
        }

        public Admin GetAdminByUsername(string username)
        {
            return adminRepository.GetByUsername(username);
        }

        public void RegisterAdmin(Admin admin)
        {
            adminRepository.Add(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            adminRepository.Update(admin);
        }

        public void DeleteAdmin(int adminId)
        {
            adminRepository.Delete(adminId);
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return adminRepository.GetAll();
        }
    }
}
