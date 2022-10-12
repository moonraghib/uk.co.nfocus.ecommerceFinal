using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerceFinal.PageObjectModels
{
    public class CartPOM
    {
        public string url = "https://www.edgewordstraining.co.uk/demo-site/cart/";
        public By couponInput = By.Id("coupon_code");
        public By couponButton = By.CssSelector("button[name='apply_coupon']");
        public By removeCouponButton = By.CssSelector(".woocommerce-remove-coupon");
        public By checkoutButton = By.CssSelector(".alt.button.checkout-button.wc-forward");
        public By discountAmount = By.CssSelector(".cart-discount.coupon-edgewords > td > .amount.woocommerce-Price-amount");
        public By subtotal = By.CssSelector("#post-5 > div > div > form > table > tbody > tr.woocommerce-cart-form__cart-item.cart_item > td.product-subtotal > span");
        public By shipping = By.CssSelector("#shipping_method > li > label > span > bdi");
        public By total = By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.order-total > td > strong > span");
    }    
    }