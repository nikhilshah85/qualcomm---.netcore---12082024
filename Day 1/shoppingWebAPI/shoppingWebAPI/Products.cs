namespace shoppingWebAPI
{
    public class Products
    {
        #region Properties
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }
        #endregion

        #region Data
        private static List<Products> Plist = new List<Products>()
        {
            new Products { pId=101, pName="Pepsi", pCategory="Cold-Drink", pIsInStock=true, pPrice=50},
            new Products { pId=102, pName="Maggie", pCategory="Fast-Food", pIsInStock=true, pPrice=80},
            new Products { pId=103, pName="Sandwitch", pCategory="Fast-Food", pIsInStock=false, pPrice=120},
            new Products { pId=104, pName="Dell Lattitude", pCategory="Laptop", pIsInStock=true, pPrice=50000},
        };
        #endregion

        #region Methods for API - CRUD Operation

        #region Get Methods
        public List<Products> GetAllProducts()
        {
            return Plist;
        }

        public Products GetProductById(int id)
        {
            var pd = (from p in Plist
                      where p.pId == id select p).Single();

            if (pd != null)
            {
                return pd;
            }
            throw new Exception("Product Not Found");
        }

        public int GetTotalProducts()
        {
            return Plist.Count;
        }

        public List<Products> GetByAvability(bool yesno)
        {
            var pd = (from p in Plist
                     where p.pIsInStock == yesno
                     select p).ToList();
            return pd;
        }
        #endregion

        #region Post Methods
        public string AddProduct(Products newProduct)
        {
            //do some validations, calculations, formatting
            Plist.Add(newProduct);
            return "Product Added Successfully";
        }
        #endregion

        #region Put Method
        public string UpdateProduct(Products product)
        {
            var pr = (from p in Plist
                      where p.pId == product.pId
                      select p).Single();

            if (pr != null) 
            {
                pr.pName = product.pName;
                pr.pCategory = product.pCategory;
                pr.pPrice = product.pPrice;
                pr.pIsInStock = product.pIsInStock;
                return "Product Updated Successfully";
            }
            throw new Exception("Product Not Found");
        }
        #endregion

        #region Delete Product
        public string DeleteProduct(int id) 
        {
            var pr = (from p in Plist
                      where p.pId == id
                      select p).Single();

            if (pr != null)
            {

                Plist.Remove(pr);

            }
            throw new Exception("Product Not Found");
        }
        #endregion


        #endregion

    }
}





