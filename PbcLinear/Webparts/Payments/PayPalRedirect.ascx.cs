using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Ecommerce;
using CMS.EcommerceProvider;
using CMS.EventLog;
using CMS.Helpers;
using CMS.PortalControls;
using CMS.PortalEngine;
using FiftyOne;
using Lucene.Net.Search;



namespace PbcLinear.Web.PbcLinear.Webparts.Payments
{
    public partial class PayPalRedirect : CMSAbstractWebPart
    {

        #region "Variables"

        /// <summary>
        /// Payment gateway provider.
        /// </summary>
        private CMSPaymentGatewayProvider mPaymentGatewayProvider;
        private int orderId;
        private ShoppingCartInfo mShoppingCart;
        #endregion


        #region "Properties"

        private ShoppingCartInfo ShoppingCart
        {
            get
            {
                return mShoppingCart ?? (mShoppingCart = ShoppingCartInfoProvider.GetShoppingCartInfoFromOrder(orderId));
            }
        }


        /// <summary>
        /// Payment gateway provider instance.
        /// </summary>
        public CMSPaymentGatewayProvider PaymentGatewayProvider
        {
            get
            {
                if ((mPaymentGatewayProvider == null) && (ShoppingCart != null))
                {
                    // Get payment gateway provider instance
                    mPaymentGatewayProvider = CMSPaymentGatewayProvider.GetPaymentGatewayProvider(ShoppingCart.ShoppingCartPaymentOptionID);
                }

                return mPaymentGatewayProvider;
            }
            set
            {
                mPaymentGatewayProvider = value;
            }
        }


        /// <summary>
        /// Page where the user should be redirected after successful payment.
        /// </summary>
        public string RedirectAfterPurchase
        {
            get
            {
                return ValidationHelper.GetString(GetValue("RedirectAfterPurchase"), "");
            }
            set
            {
                SetValue("RedirectAfterPurchase", value);
            }
        }


        /// <summary>
        /// Button text to be displayed on Process payment button.
        /// </summary>
        public string ProcessPaymentButtonText
        {
            get
            {
                return ValidationHelper.GetString(GetValue("ProcessPaymentButtonText"), "");
            }
            set
            {
                SetValue("ProcessPaymentButtonText", value);
            }
        }

        #endregion


        #region "Page methods"

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnsureChildControls();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var isLiveSite = (PortalContext.ViewMode == ViewModeEnum.LiveSite) || IsLiveSite;
            // Allow provider initialization and redirection only for live site attempts
            if (isLiveSite && ((PaymentGatewayProvider == null) && (orderId > 0)))
            {
                URLHelper.Redirect(RedirectAfterPurchase);
            }

            // Cancel setup for undefined cart.
            if (ShoppingCart != null)
            {
                SetupControl();
            }

            btnProcessPayment.Text = ProcessPaymentButtonText;

            ProcessPayment();
        }

        #endregion

        private void ProcessPayment()
        {
            if ((PaymentGatewayProvider != null) && (orderId > 0))
            {
                OrderInfo order = OrderInfoProvider.GetOrders()
                    .WhereEquals("OrderID", orderId)
                    .FirstObject;

                CustomerInfo customer = CustomerInfoProvider.GetCustomers()
                    .WhereEquals("CustomerID", order.OrderCustomerID)
                    .FirstObject;

                //AddressInfo address = AddressInfoProvider.GetAddresses()
                //    .WhereEquals("AddressCustomerID", order.OrderBillingAddress)
                //    .FirstObject;

                try
                {
                    ltrPayPalForm.Text = GeneratePayPalToken(order, customer);
                }
                catch (Exception ex)
                {

                    Response.Write(ex.InnerException);
                }
            }
        }

        protected void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if ((PaymentGatewayProvider != null) && (orderId > 0))
            {

               
                OrderInfo order = OrderInfoProvider.GetOrders()
                    .WhereEquals("OrderID", orderId)
                    .FirstObject;

                CustomerInfo customer = CustomerInfoProvider.GetCustomers()
                    .WhereEquals("CustomerID", order.OrderCustomerID)
                    .FirstObject;

                //AddressInfo address = AddressInfoProvider.GetAddresses()
                //    .WhereEquals("AddressCustomerID", order.OrderBillingAddress)
                //    .FirstObject;

                try
                {
                    ltrPayPalForm.Text = GeneratePayPalToken(order, customer);
                }
                catch (Exception ex)
                {

                    Response.Write(ex.InnerException);
                }
            }
        }

        protected override void CreateChildControls()
        {
            string orderHash = QueryHelper.GetString("o", string.Empty);
            orderId = ValidationHelper.GetInteger(WindowHelper.GetItem(orderHash), 0);

            base.CreateChildControls();

            var provider = PaymentGatewayProvider;
            if (provider != null)
            {
                try
                {
                    // Init paymentDataContainer
                    Control paymentDataForm = LoadControl(provider.GetPaymentDataFormPath());
                    provider.InitializeGatewayControl(pnlPaymentDataContainer, paymentDataForm);
                    provider.OrderId = orderId;
                }
                catch (Exception ex)
                {
                    EventLogProvider.LogException("PaymentForm", "EXCEPTION", ex);
                }
            }
        }

        private void SetupControl()
        {
            // Payment and order summary
            lblTotalPriceValue.Text = CurrencyInfoProvider.GetFormattedPrice(ShoppingCart.RoundedTotalPrice, ShoppingCart.Currency);
            lblOrderIdValue.Text = Convert.ToString(orderId);

            if (ShoppingCart.PaymentOption != null)
            {
                lblPaymentValue.Text = ResHelper.LocalizeString(ShoppingCart.PaymentOption.PaymentOptionDisplayName, null, true);
            }

            // Payment form is visible only if payment method is selected
            if (PaymentGatewayProvider == null)
            {
                ShowError(GetString("com.checkout.paymentoptionnotselected"));
            }
        }

      
        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
        }

        #region PayPal

        private string GeneratePayPalToken(OrderInfo order,  CustomerInfo customer)
        {
            string output = string.Empty;
            string invoiceTotal = string.Empty;

            if (customer.CustomerEmail.Contains("@ascedia.com"))
            {
                invoiceTotal = Convert.ToString(1.00);
            }
            else
            {
                invoiceTotal = Convert.ToString(order.OrderTotalPrice);
            }

            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/";

            NameValueCollection requestArray = new NameValueCollection()
            {
                //Testing partner
                {"PARTNER", "PayPal"},
                //{"PARTNER", "verisign"},
                //Test vendor
                {"VENDOR", "jjknaak"},           
                //Test user
                {"USER", "jjknaak"},
                //Test password
                {"PWD", "@sc3d1a2016"},
                {"AMT", invoiceTotal},
                //{"AMT", Convert.ToString(5.00)},
                {"TRXTYPE", "A"},
                {"INVNUM", Convert.ToString(order.OrderID)},
                {"CURRENCY", "USD"},
                //{"RETURNURL", "/home"},

                {"BILLTOFIRSTNAME", customer.CustomerFirstName},
                //{"BILLTOSTREET", address.AddressLine1},
                //{"BILLTOCITY", address.AddressCity},
                //{"BILLTOZIP", address.AddressZip},
                //{"BILLTOCOUNTRY", (invoice.BillCountry == "United States") ? "United States of America": invoice.BillCountry},

                {"CREATESECURETOKEN", "Y"},
                {"SECURETOKENID", genId()},
            };

            //PayPal return URL
            if (Session["PayPalReturnUrl"] != null && Session["PayPalReturnUrl"].ToString() != String.Empty)
            {
                requestArray.Add("RETURNURL", Session["PayPalReturnUrl"].ToString());
            }
            else
            {
                //TODO: add correct url
                requestArray.Add("RETURNURL", baseUrl + "na/estore/confirmation.aspx");
            }

            //PayPal Error URL
            if (Session["PayPalErrorUrl"] != null && Session["PayPalErrorUrl"].ToString() != String.Empty)
            {
                requestArray.Add("ERRORURL", Session["PayPalErrorUrl"].ToString());
            }
            else
            {
                //TODO: add correct url

                requestArray.Add("ERRORURL", baseUrl + "na/estore/checkout.aspx");
            }
            
            
            NameValueCollection resp = run_payflow_call(requestArray);

            if (resp["RESULT"] != "0")
            {
                output += "Payflow call failed " + resp["RESULT"].ToString();
                output += resp["RESPMSG"].ToString();
            }
            else
            {
                output += CreatePayPalForm(resp);
                //SECURETOKEN.Value = resp["SECURETOKEN"].ToString();
                //SECURETOKENID.Value = resp["SECURETOKENID"].ToString();
            }

            return output;  //end of hosted checkout pages flow

            // return resp;
        }

        private string CreatePayPalForm(NameValueCollection nvc)
        {
            string urlEndpoint = "https://pilot-payflowpro.paypal.com";
            //string urlEndpoint = "https://payflowpro.paypal.com";
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<form method=\"POST\" action=\"" + urlEndpoint + "\" id=\"paypalForm\">");
            sb.AppendFormat("<input type=\"hidden\" value=\"{0}\" name=\"SECURETOKEN\"/>", nvc["SECURETOKEN"]);
            sb.AppendFormat("<input type=\"hidden\" value=\"{0}\" name=\"SECURETOKENID\" />", nvc["SECURETOKENID"]);
            sb.AppendFormat("<input type=\"submit\" value=\"{0}\" style=\"display:hidden;\"/>", "Continue");
            sb.Append("</form>");
            return sb.ToString();
        }

        // Run Payflow request and return an array with the response
        protected NameValueCollection run_payflow_call(NameValueCollection requestArray)
        {
            String nvpstring = "";
            foreach (string key in requestArray)
            {
                //format:  "PARAMETERNAME[lengthofvalue]=VALUE&".  Never URL encode.
                var val = RemoveDiacritics(requestArray[key]);
                nvpstring += key + "[" + val.Length + "]=" + val + "&";
            }

            string urlEndpoint;

            //send request to Payflow
            //urlEndpoint = "https://payflowpro.paypal.com";
            //Test urlendpoint
            urlEndpoint = "https://pilot-payflowpro.paypal.com";
            HttpWebRequest payReq = (HttpWebRequest)WebRequest.Create(urlEndpoint);

            try
            {
                payReq.Method = "POST";
                payReq.ContentLength = nvpstring.Length;
                payReq.ContentType = "application/x-www-form-urlencoded";

                StreamWriter sw = new StreamWriter(payReq.GetRequestStream());
                sw.Write(nvpstring);

                var temp = sw.ToString();

                sw.Flush();
                sw.Close();

            }
            catch (Exception ex)
            {
                string msg = ex.InnerException + "-------" + ex.Message + " -------" + ex.StackTrace + "-------NVPstring: " + nvpstring;
            }

            //get Payflow response
            HttpWebResponse payResp = (HttpWebResponse)payReq.GetResponse();
            StreamReader sr = new StreamReader(payResp.GetResponseStream());
            string response = sr.ReadToEnd();
            sr.Close();

            //parse string into array and return
            NameValueCollection dict = new NameValueCollection();
            string respInfo = "";
            foreach (string nvp in response.Split('&'))
            {
                string[] keys = nvp.Split('=');
                dict.Add(keys[0], keys[1]);
                respInfo += keys[0] + "---" + keys[1] + "<br>";
            }
            return dict;
        }

        // generates a random unique ID for use in the initial CREATESECURETOKEN=Y request
        protected string genId()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 16)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            //return "MySecTokenID-" + result; //add a prefix to avoid confusion with the "SECURETOKEN"
            return result;
        }

        public static String RemoveDiacritics(String s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}