using CloudOrderApi.CloudModels;

namespace CloudOrderApi.Services
{
    public interface ICloudOrderService
    {
        CloudModelResponse GetCloudById(int id);
        IEnumerable<CloudModelResponse> GetAllClouds();
        void CreateCloud(CloudModelRequest cloudModeRequest);
    }
}
