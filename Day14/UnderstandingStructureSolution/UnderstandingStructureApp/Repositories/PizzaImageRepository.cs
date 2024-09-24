using UnderstandingStructureApp.Exceptions;
using UnderstandingStructureApp.Interfaces;
using UnderstandingStructureApp.Models;

namespace UnderstandingStructureApp.Repositories
{
    public class PizzaImageRepository : IRepository<int, PizzaImages>
    {
        List<PizzaImages> images = new List<PizzaImages>
        {
            new PizzaImages(){Id = 1, Images = new List<string>(){ "/images/margherita.jpg", "/images/margherita1.jpg", "/images/margherita2.jpg" } },
            new PizzaImages(){Id = 2, Images = new List<string>(){ "/images/pepperoni.jpg", "/images/pepperoni1.jpg", "/images/pepperoni2.jpg" } }
        };
        public PizzaImages Add(PizzaImages item)
        {
            if (item.Images.Count == 0)
                throw new CannotAddWithNoImagesException();
            images.Add(item);
            return item;
        }

        public PizzaImages Delete(int key)
        {
            var myImages = Get(key);
            if (myImages == null)
                throw new NoSuchImageException();
            images.Remove(myImages);
            return myImages;
        }

        public PizzaImages Get(int key)
        {
            var imgage = images.FirstOrDefault(i => i.Id == key);
            if (imgage == null)
                throw new NoSuchImageException();
            return imgage;
        }

        public List<PizzaImages> GetAll()
        {
            if(images.Count == 0)
                throw new NoImagesException();
            return images;
        }

        public PizzaImages Update(PizzaImages pizza)
        {
            if(pizza.Images.Count == 0)
                throw new CannotUpdateWithNoImagesException();
            var myImages = Get(pizza.Id);
            if (myImages == null)
                throw new NoSuchImageException();
            myImages.Images = pizza.Images;
            return myImages;
        }
    }
}
