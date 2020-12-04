using CicekSepeti.Core.IUnitOfWork;
using CicekSepeti.Domain.Entities;
using CicekSepeti.Service.IServices;
using CicekSepeti.Service.ResponseApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Service
{
    public class BasketService : IBasketService
    {

        private readonly IUnitOfWork _unitOfWork;
        public BasketService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Basket> AddBasket(Basket basket)
        {
            var user = await _unitOfWork.UserRepositories.GetByIdAsync(basket.UserId);
            var product = await _unitOfWork.ProductRepositories.GetByIdAsync(basket.ProductId);

            if (user == null || product == null)
            {
                return null;

                //throw new Exception("Kullanıcı yada ürün sistemde kayıtlı değildir.");
            }

            if (product.Count == 0)
            {
                return null;
            }
            var basketIsExist = await GetBasketsByUserIdAndProductId(basket.UserId, basket.ProductId);

            if (basketIsExist == null)
            {
                basket.Count = 1;
                await _unitOfWork.BasketRepositories.AddAsync(basket);
            }
            else
            {
                basketIsExist.Count++;
                _unitOfWork.BasketRepositories.Update(basketIsExist);

            }

            product.Count--;
            _unitOfWork.ProductRepositories.Update(product);


            await _unitOfWork.CommitAsync();

            return basket;
        }

        public async Task<ApiResponse> AddBasketApiResponse(Basket basket)
        {
            var user = await _unitOfWork.UserRepositories.GetByIdAsync(basket.UserId);
            var product = await _unitOfWork.ProductRepositories.GetByIdAsync(basket.ProductId);

            if (user == null || product == null)
            {

                return new ApiNotFoundResponse(basket, "Ürün veya kullanıcı bulunamadı");
                //return null;

                //throw new Exception("Kullanıcı yada ürün sistemde kayıtlı değildir.");
            }

            if (product.Count == 0)
            {
                return new ApiNotFoundResponse(product, "Ürün sotğu yeterli değil.");
                //return null;
            }
            var basketIsExist = await GetBasketsByUserIdAndProductId(basket.UserId, basket.ProductId);

            if (basketIsExist == null)
            {
                basket.Count = 1;
                await _unitOfWork.BasketRepositories.AddAsync(basket);
            }
            else
            {
                basketIsExist.Count++;
                _unitOfWork.BasketRepositories.Update(basketIsExist);

            }

            product.Count--;
            _unitOfWork.ProductRepositories.Update(product);


            await _unitOfWork.CommitAsync();

            return new ApiOkResponse(basket);
        }

        public async Task<ResponseTest> AddBasketApiResponseTest(Basket basket)
        {
            var user = await _unitOfWork.UserRepositories.GetByIdAsync(basket.UserId);
            var product = await _unitOfWork.ProductRepositories.GetByIdAsync(basket.ProductId);

            var valid = await Validations(basket, user, product);
            if (valid.IsSuccess == false)
            {
                return valid;
            }

            var basketIsExist = await GetBasketsByUserIdAndProductId(basket.UserId, basket.ProductId);

            if (basketIsExist == null)
            {
                //basket.Count = 1;
                await _unitOfWork.BasketRepositories.AddAsync(basket);
            }
            else
            {
                basketIsExist.Count += basket.Count;
                _unitOfWork.BasketRepositories.Update(basketIsExist);

            }

            product.Count = product.Count - basket.Count;
            _unitOfWork.ProductRepositories.Update(product);


            await _unitOfWork.CommitAsync();

            return new ResponseTest
            {
                IsSuccess = true,
                Message = "Sepet güncellendi."
            };
        }

        private async Task<ResponseTest> Validations(Basket basket, User user, Product product)
        {
            if (user == null)
            {

                return new ResponseTest
                {
                    IsSuccess = false,
                    Message = "Kullanıcı bulunamadı."
                };
            }

            if (product == null)
            {

                return new ResponseTest
                {
                    IsSuccess = false,
                    Message = "Ürün bulunamadı"
                };
            }

            if (product.Count < basket.Count)
            {
                return new ResponseTest
                {
                    IsSuccess = false,
                    Message = $"Bu üründen {basket.Count} adet bulanmamaktadır. Stokta {product.Count} adet ürün vardır."
                };
            }

            return new ResponseTest { IsSuccess = true };
        }

        public async Task<IEnumerable<Basket>> GetAllBaskets()
        {
            return await _unitOfWork.BasketRepositories.GetAllAsync();
        }
        public async Task<IEnumerable<Basket>> GetAllBasketsByUserId(Guid userId)
        {
            return await _unitOfWork.BasketRepositories.GetBasketsByUserId(userId);
        }

        private async Task<Basket> GetBasketsByUserIdAndProductId(Guid userId, Guid productId)
        {
            return await _unitOfWork.BasketRepositories.GetBasketsByUserIdAndProductId(productId, userId);
        }
    }
}
