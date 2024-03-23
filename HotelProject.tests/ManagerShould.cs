using HotelProject.Models;
using HotelProject.Repository;

namespace HotelProject.tests
{
    public class ManagerShould
    {
        private readonly ManagerRepository _managerRepository;
        public ManagerShould()
        {
            _managerRepository = new();
        }
        [Fact]
        public void Return_All_Managers_From_Database()
        {
            var result = _managerRepository.GetManagers();
        }

        [Fact]
        public void Add_New_Manager_In_Database()
        {
            Manager newManager = new()
            {
                FirstName = "ილია",
                LastName = "ჭავჭავაძე"
            };

            _managerRepository.AddManager(newManager);
        }

        [Fact]
        public void Update_Manager_In_Database()
        {
            Manager updatedManager = new()
            {
                Id = 1,
                FirstName = "აკაკი",
                LastName = "წერეთელი"
            };

            _managerRepository.UpdateManager(updatedManager);
        }

        [Fact]
        public void Delete_Manager_from_Database()
        {
            int id = 2;

            _managerRepository.DeleteManager(id);
        }
    }
}