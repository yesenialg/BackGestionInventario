using Core;

namespace Application.Contracts.Infrastructure
{
    public interface IProductRepository
    {
        Task<ProductCore> CreateAsync(ProductCore entity);

        Task<ProductCore> UpdateAsync(ProductCore entity);

        public Task<IReadOnlyCollection<ProductCore>> GetAllAsync();

        public Task<ProductCore> GetAsync(long id);

    }
}
