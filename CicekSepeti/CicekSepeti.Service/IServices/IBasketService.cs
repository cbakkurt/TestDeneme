using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.ResponseApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Service.IServices
{
    public interface IBasketService
    {
        Task<Basket> AddBasket(Basket basket);
        Task<ApiResponse> AddBasketApiResponse(Basket basket);
        Task<ResponseTest> AddBasketApiResponseTest(Basket basket);

        Task<IEnumerable<Basket>> GetAllBaskets();
        Task<IEnumerable<Basket>> GetAllBasketsByUserId(Guid userId);
    }
}
