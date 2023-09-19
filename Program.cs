class Program
{
    static void Main(string[] args)
    {
        using (var context = new Connection())
        {
            ProductController productController = new ProductController(context);
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1 - Adicionar");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Pesquisar por id");
                Console.WriteLine("4 - Atualizar nome do produto");
                Console.WriteLine("5 - Excluir");
                Console.WriteLine("6 - Sair");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                     Console.WriteLine("Nome do produto:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Preço do produto:");
                            string value = Console.ReadLine();
                        if (decimal.TryParse(value, out decimal price))
                        {
                            Console.WriteLine("Descrição do produto:");
                            string description = Console.ReadLine();

                            var newProduct = new Product
                            {
                                Name = name,
                                Price = price,
                                Description = description
                            };

                            productController.addProduct(newProduct);
                            Console.WriteLine("Produto adicionado.");
                        }
                        else
                        {
                            Console.WriteLine("Preço inválido.");
                        }
                        break;

                    case "2":

                        var products = productController.getAll().ToList();
                            foreach (var product in products)
                            {
                                Console.WriteLine($"Nome: {product.Name}, Preço: {product.Price:C}, Descrição: {product.Description}, Quantidade: {product.Quantity}");
                            }
                        break;
                    case "3":
                        Console.WriteLine("Id do produto:");
                        int id = int.Parse(Console.ReadLine());
                        
                        var product2 = productController.getById(id);
                        Console.WriteLine($"Nome: {product2.Name}, Preço: {product2.Price:C}, Descrição: {product2.Description}, Quantidade: {product2.Quantity}");
                        
                        break;
                       
                    case "4":
                        Console.WriteLine("Id do produto:");
                        int id2 = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Nome do produto:");
                        string newName = Console.ReadLine();

                        productController.Update(id2, newName);
                        Console.WriteLine("Produto atualizado com sucesso.");

                        break;

                    case "5":
                        Console.WriteLine("Id do produto:");
                        int id3 = int.Parse(Console.ReadLine());

                        productController.Delete(id3);
                        break;

                    case "6":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
