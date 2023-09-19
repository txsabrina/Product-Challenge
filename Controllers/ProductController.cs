using System;
using System.Linq;

public class ProductController
{
    private readonly Connection _context;

    public ProductController(Connection context)
    {
        _context = context;
    }


    public void addProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public Product getById(int id)
    {
        return _context.Products.Find(id);
        
    }

    public IQueryable<Product> getAll()
    {
        return _context.Products;
    }

    public void Update(int id, string name)
    {
        var productToUpdate = _context.Products.Find(id);
        productToUpdate.Name = name;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var foundProduct = _context.Products.FirstOrDefault(product => product.Id == id);
        if(foundProduct != null) 
        {
            _context.Products.Remove(foundProduct);
            _context.SaveChanges();
        }
    }
}