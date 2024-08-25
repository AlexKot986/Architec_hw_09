using CloudOrderApi.CloudModels;
using CloudOrderApi.Contexts;
using CloudOrderApi.Contexts.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudOrderApi.Services
{
    public class CloudOrderService : ICloudOrderService
    {
        private CloudDBContext _dbContext;

        public CloudOrderService(CloudDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private void CreateOrder(int  id)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
                throw new Exception("Не найден клиент!");

            _dbContext.Add(new Order { ClientId = id });
            _dbContext.SaveChanges();
        }
        public void CreateCloud(CloudModelRequest cloudModel)
        {
            CreateOrder(cloudModel.ClientId);

            var order = _dbContext.Orders.OrderBy(ord => ord).LastOrDefault(ord => ord.ClientId == cloudModel.ClientId);
            if (order is null)
                throw new Exception("Не удалось создать заказ!");

            var findCloud = _dbContext.Clouds.FirstOrDefault(cld => cld.OrederId == order.Id);
            if (findCloud is not null)
                throw new Exception("Такое облако уже существует, не удалось создать заказ!");

            var os = _dbContext.OSs.FirstOrDefault(o => o.Name == cloudModel.OS);
            if (os is null)
                throw new Exception("Не найдена ОС!");

            _dbContext.Clouds.Add(new Cloud
            {       
                OrederId = order.Id,
                OSId = os.Id,
                CoresNumber = cloudModel.CoresNumber,
                RamVolume = cloudModel.RamVolume,
                HddVolume = cloudModel.HddVolume,
                Address = cloudModel.Address
            });

            _dbContext.SaveChanges();
        }

        public IEnumerable<CloudModelResponse> GetAllClouds()
        {
            var orders = _dbContext.Orders.ToList();                        

            foreach (var cloud in _dbContext.Clouds)
            {
                yield return new CloudModelResponse
                {
                    Id = cloud.Id,
                    ClientId = orders.First(o => o.Id == cloud.OrederId).ClientId, 
                    OS = (OSDto)cloud.OSId,
                    CoresNumber = cloud.CoresNumber,
                    RamVolume = cloud.RamVolume,
                    HddVolume = cloud.HddVolume,
                    Address = cloud.Address,
                };
            }
        }

        public CloudModelResponse GetCloudById(int id)
        {
            var cloud = _dbContext.Clouds.FirstOrDefault(c => c.Id == id);
            if (cloud is null)
                throw new Exception($"Облака с id: {id} нет в базе!");

            var cloudDto = new CloudModelResponse()
            {
                Id = cloud.Id,
                ClientId = _dbContext.Orders.First(or => or.Id == cloud.OrederId).ClientId,
                OS = (OSDto) cloud.OSId,
                CoresNumber = cloud.CoresNumber,
                RamVolume = cloud.RamVolume,
                HddVolume = cloud.HddVolume,
                Address = cloud.Address,
            };

            return cloudDto;
        }
    }
}
