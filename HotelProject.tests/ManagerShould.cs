using HotelProject.Models;
using HotelProject.Repository.MicrosoftDataSQLClient;

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
        public async void Return_All_Managers_From_Database()
        {
            var result = await _managerRepository.GetManagers();
        }

        [Fact]
        public async void Add_New_Manager_In_Database()
        {
            Manager newManager = new()
            {
                FirstName = "ილია",
                LastName = "ჭავჭავაძე",
                HotelId = 13
            };

            await _managerRepository.AddManager(newManager);
        }

        [Fact]
        public async void Update_Manager_In_Database()
        {
            Manager updatedManager = new()
            {
                Id = 16,
                FirstName = "იაკობ",
                LastName = "გოგებაშვილი",
                HotelId= 13
            };

            await _managerRepository.UpdateManager(updatedManager);
        }

        [Fact]
        public async void Delete_Manager_from_Database()
        {
            int id = 4;

            await _managerRepository.DeleteManager(id);
        }
    }
}