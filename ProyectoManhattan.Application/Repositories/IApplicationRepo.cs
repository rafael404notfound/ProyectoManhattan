using Domain.Entities;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManhattan.Application
{
    public interface IApplicationRepo
    {
        public void Create(Brand entity);
        public void Delete(int id);
        public void Delete(string name);
        public Task<Brand> Get(int id);
        public Task<Brand> Get(string name);
        public IQueryable<Brand>GetAllWithoutIncludes();

        public IQueryable<Brand> GetAll();
        public Task Update(Brand brand);
        public Task Operate(Brand brand, Operation operation);
        /*public async Task Update(Cat entity)
        {
            // entity as it currently exists in the db
            var cat = DbContext.Cats.Include(c => c.Photos)
                .FirstOrDefault(p => p.Id == entity.Id);
            // update properties on the parent
            DbContext.Entry(cat).CurrentValues.SetValues(entity);
            // remove or update child collection items
            var catPhotos = cat.Photos;
            foreach (var catPhoto in catPhotos)
            {
                var photo = entity.Photos.SingleOrDefault(p => p.Id == catPhoto.Id);
                if (photo != null)
                {
                    //no need to change the photo since photos never change, htey are only added or removed
                    //DbContext.Entry(catPhotos).CurrentValues.SetValues(photo);
                }
                else
                    DbContext.Remove(catPhoto);
            }
            // add the new items
            foreach (var photo in entity.Photos)
            {
                if (catPhotos.All(i => i.Id != photo.Id))
                {
                    cat.Photos.Add(photo);
                }
            }
            /*var dbEntity = DbContext.Cats.Include(c => c.Photos).Single(c => c.Id == entity.Id);
            DbContext.Entry(dbEntity).CurrentValues.SetValues(entity);

            if (dbEntity.Photos != null)
            {
                if (entity.Photos != null)
                {
                    foreach(var photo in dbEntity.Photos)
                    {
                        if(entity.Photos.FirstOrDefault(p => p.Id == photo.Id) != null)
                        {
                            DbContext.Entry(dbEntity.Photos.Single(p => p.Id == photo.Id)).CurrentValues.SetValues(entity.Photos.Single(p => p.Id == photo.Id));
                        }
                        else
                        {
                            // Remove deleted image
                            context.SubFoos.Attach(newFoo.SubFoo);
                            dbFoo.SubFoo = newFoo.SubFoo;
                        }
                    }
                }
                else // relationship has been removed
                    dbFoo.SubFoo = null;
            }
            else
            {
                if (newFoo.SubFoo != null) // relationship has been added
                {
                    // Attach assumes that newFoo.SubFoo is an existing entity
                    context.SubFoos.Attach(newFoo.SubFoo);
                    dbFoo.SubFoo = newFoo.SubFoo;
                }
                // else -> old and new SubFoo is null -> nothing to do
            }
            await DbContext.SaveChangesAsync();
        }*/
    }
}
