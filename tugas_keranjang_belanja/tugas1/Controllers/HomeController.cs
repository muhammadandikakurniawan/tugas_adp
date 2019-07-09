using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tugas1.Models;

namespace tugas1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("productlist")]
        public ActionResult ProductList()
        {
            Product Product = new Product();
            List<Product> ProductList = Product.GetListProduct();
            return View(ProductList);
        }

        [ActionName("addcart")]
        [Route("addcart/{id?}")]
        public ActionResult AddToCart(string id = "")
        {
            if(id == "")
            {
                return Redirect("~/productlist");
            }
            if(new Product().GetListProduct().FindAll(p => p.ProductId.Equals(id)).Count != 1)
            {
                return Redirect("~/productlist");
            }
            Product product = new Product();
            product = (Product)product.GetListProduct().Find(p => p.ProductId.Equals(id));

            if (TempData.Peek("cart") == null)
            {
                List<Cart> ListCarts = new List<Cart>();
                TempData.Add("cart", ListCarts);
            }
            List<Cart> ListCart = (List<Cart>)TempData.Peek("cart");
            if (ListCart.Contains(ListCart.Find(c => c.ProductId.Equals(id))))
            {
                int index = ListCart.FindIndex(c => c.ProductId.Equals(id));
                ListCart[index].Qty = ListCart[index].Qty + 1;
                ListCart[index].SubTotal = ListCart[index].GetProduct().ProductPrice * ListCart[index].Qty;
                return Redirect("~/cart");

            }
            return View("AddToCart",product);
        }

        [HttpPost]
        [ActionName("addcart")]
        [Route("addcart")]
        public ActionResult AddToCart(Cart cart)
        {
            if (cart == null)
            {
                return Redirect("~/productlist");
            }
            Product product = new Product();
            if (product.GetListProduct().FindAll(p => p.ProductId.Equals(cart.ProductId)).Count != 1)
            {
                return Redirect("~/productlist");
            }
            if (TempData.Peek("cart") == null)
            {
                return Redirect("~/productlist");

            }
            List<Cart> ListCart = (List<Cart>)TempData.Peek("cart");
            ListCart.Add(cart);
            TempData.Add("message", "Product by id " + cart.ProductId + " added succesfully");
            TempData.Add("type", "success");
            return Redirect("~/cart");
        }

        [Route("cart")]
        public ActionResult Cart()
        {
            if (TempData.Peek("cart") == null)
            {
                List<Cart> Cart = new List<Cart>() {
                    new Cart
                    {
                        ProductId = "",
                        Qty = 0,
                        SubTotal = 0,
                    }
                };

                return View("Cart", Cart);
            }
            List<Cart> ListCart = (List<Cart>)TempData.Peek("cart");

            ListCart.RemoveAll(e => e.Qty == 0);
            return View("Cart", ListCart);
        }

        [Route("deletecart/{id?}")]
        public ActionResult DeleteCart(string id = "")
        {
            if(id == "")
            {
                return Redirect("~/cart");
            }
            if(TempData.Peek("cart") == null)
            {
                return Redirect("~/cart");
            }
            List<Cart> ListCart = (List<Cart>)TempData.Peek("cart");
            ListCart.RemoveAll(c => c.GetProduct().ProductId.Equals(id));
            TempData.Add("message", "Product by id " + id + " deleted succesfully");
            TempData.Add("type", "danger");
            return Redirect("~/cart");
        }

        [HttpGet]
        [Route("updatecart/{id?}")]
        public ActionResult UpdateCart(string id = "")
        {
            if(TempData.Peek("cart") == null)
            {
                return Redirect("~/cart");
            }
            if(id == "")
            {
                return Redirect("~/cart");
            }
            List<Cart> ListCart = (List<Cart>)TempData.Peek("cart");
            Cart cart = ListCart.Find(c => c.GetProduct().ProductId.Equals(id));
            return View("UpdateCart",cart);
        }

        [HttpPost]
        [Route("updatecart")]
        public ActionResult UpdateCart(Cart cart)
        {
            if (TempData.Peek("cart") == null)
            {
                return Redirect("~/cart");
            }
            if (cart == null)
            {
                return Redirect("~/cart");
            }
            List<Cart> ListCart = (List<Cart>)TempData.Peek("cart");
            int index = ListCart.FindIndex(c => c.GetProduct().ProductId.Equals(cart.ProductId));
            ListCart[index] = cart;
            TempData.Add("message", "Product by id " + cart.ProductId + " edited succesfully");
            TempData.Add("type", "primary");
            return Redirect("~/cart");
        }
    }
}