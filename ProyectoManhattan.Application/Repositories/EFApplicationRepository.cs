using Domain.Entities;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace ProyectoManhattan.Application
{
    public class EFApplicationRepository : IApplicationRepo
    {
        IApplicationDbContext DbContext;
        public EFApplicationRepository(IApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Create(Brand entity)
        {
            
            DbContext.Brands.Add(entity);
            DbContext.SaveChanges();
        }

        // Returns false if an the entity didnt exist
        public void Delete(int id)
        {
            var brand = DbContext.Brands.Include(b => b.ShoeModels).ThenInclude(s => s.Sizes).FirstOrDefault(b => b.Id == id);
            DbContext.Brands.Remove(brand);
            DbContext.SaveChanges();
        }
        public void Delete(string name)
        {
            DbContext.Brands.Remove(new Brand { DisplayName = name });
            DbContext.SaveChanges();
        }

        public async Task<Brand> Get(int id)
        {
            return await DbContext.Brands.Include(b => b.ShoeModels).ThenInclude(s => s.Sizes).FirstOrDefaultAsync(b => b.Id == id) ?? new Brand();
        }

		public async Task<Brand> Get(string name)
		{
			return await DbContext.Brands.Include(b => b.ShoeModels).ThenInclude(s => s.Sizes).FirstOrDefaultAsync(b => b.DisplayName == name) ?? new Brand();
		}

		public IQueryable<Brand> GetAll()
        {
            return DbContext.Brands.Include(b => b.ShoeModels).ThenInclude(s => s.Sizes);
        }

        public async Task Operate(Brand brand, Operation operation)
        {
            if (brand.DisplayName == null)
            {
                throw new Exception("brand.DisplayName cannot be null");
            }

            Brand entity = DbContext.Brands.Include(b => b.ShoeModels).ThenInclude(s => s.Sizes).FirstOrDefault(b => b.SapName == brand.SapName) ?? new Brand();
            foreach (var newShoeModel in brand.ShoeModels)
            {
                var shoeModelInDb = entity.ShoeModels.Where(s => s.RefWithOutSize == newShoeModel.RefWithOutSize).FirstOrDefault();

                // add shoe model if its not in stock already
                if (shoeModelInDb is null)
                {
                    entity.ShoeModels.Add(newShoeModel); 
                }
                // add new shoes count to ShoeModel.Sizes.Count if shoe model is in stock 
                else 
                {
                    foreach(var newShoeSize in newShoeModel.Sizes)
                    {
                        var shoeSizeInDb = shoeModelInDb.Sizes.Where(s => s.Size == newShoeSize.Size).FirstOrDefault();
                        switch(operation)
                        {
                            case Operation.Add:
                                shoeSizeInDb!.Count += newShoeSize.Count;
                                break;

                            case Operation.Substract:
                                shoeSizeInDb!.Count -= newShoeSize.Count;
                                // set shoe count to 0 if for some error gets lower than 0;
                                if (shoeSizeInDb!.Count < 0)
                                {
                                    shoeSizeInDb.Count = 0;
                                }
                                // if every size count in a ShoeModel is 0 remove ShoeModel from db
                                if (shoeSizeInDb.Id == shoeModelInDb.Sizes.Last().Id 
                                    && shoeModelInDb.Sizes.Where(s => s.Count > 0).FirstOrDefault() is null)
                                {
                                    entity.ShoeModels.Remove(shoeModelInDb);                                    
                                }
                                break;
                        }                        
                    }
                }
            }
            // remove Brand it there are no more shoes left in the store
            if (entity.ShoeModels.Count() == 0)
            {
                DbContext.Brands.Remove(entity);
            }
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(Brand entity)
        {
            DbContext.Brands.Update(entity);
            await DbContext.SaveChangesAsync();
            /*
            // entity as it currently exists in the db
            var brand = DbContext.Brands.Include(b => b.ShoeModels).ThenInclude(s => s.Sizes)
                .FirstOrDefault(b => b.Id == entity.Id);
            // update properties on the parent
            DbContext.Entry(brand).CurrentValues.SetValues(entity);
            // remove or update child collection items
            var shoeModels= brand.ShoeModels;
            foreach (var shoeModel in shoeModels)
            {
                var shoeModelEntity = entity.ShoeModels.SingleOrDefault(p => p.Id == shoeModel.Id);
                if (shoeModelEntity != null)
                {                    
                    DbContext.Entry(shoeModel).CurrentValues.SetValues(shoeModelEntity);
                }
                else
                    DbContext.Remove(shoeModel);
            }
            // add the new items
            foreach (var shoeModel in entity.ShoeModels)
            {
                if (shoeModels.All(i => i.Id != shoeModel.Id))
                {
                    brand.ShoeModels.Add(shoeModel);
                }
            }*/
        }
    }
}
