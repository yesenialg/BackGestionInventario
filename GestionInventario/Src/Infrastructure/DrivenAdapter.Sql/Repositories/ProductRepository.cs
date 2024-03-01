using Application.Contracts.Infrastructure;
using AutoMapper;
using Core;
using DrivenAdapter.Sql.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DrivenAdapter.Sql.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductCore> CreateAsync(ProductCore entity)
        {
            var entityMapped = _mapper.Map<Product>(entity);
            _context.Products.Add(entityMapped);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyCollection<ProductCore>> GetAllAsync()
        {
            var list = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductCore>>(list);
        }

        public async Task<ProductCore> GetAsync(long id)
        {
            var entity = await _context.Products.FindAsync(id);
            var entityMapped = _mapper.Map<ProductCore>(entity);
            return entityMapped;
        }

        public async Task<ProductCore> UpdateAsync(ProductCore entity)
        {
            var existingEntity = await _context.Products.FindAsync(entity.Id);

            if (existingEntity == null)
            {
                throw new Exception("La entidad no fue encontrada en la base de datos.");
            }

            _mapper.Map(entity, existingEntity);

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
