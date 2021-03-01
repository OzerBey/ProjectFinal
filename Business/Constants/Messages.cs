using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages //sürekli new lememek için ve sabit oldugu için 'static' olarak verdik !!
    {
        //Public olanlar Pascal Case yazılır ...=> ProducAddedMessage gibi
        public static string ProductAdded = "Product has been added.";
        public static string ProductNameInvalid = "ProductName is invalid";
        public static string MaintananceTime = "System maintenance ";
        public static string ProductListed = "Product has been listed";
        public static string ProductCountOfCategoryError = "categories' the number of products should not be more than 10";
        public static string ProductNameAlreadyExists = "This ProductName already exists";
        public static string CategoryLimitExceded = "Category limit is over so new product didn't add";
        public static string AuthorizationDenied = "You are not authorized";
        public static string UserRegistered= "User registered";
        public static string UserNotFound="User not found";
        public static string PasswordError="Password Error";
        public static string SuccessfulLogin="Successful login ";
        public static string UserAlreadyExists= "User already exists";
        public static string AccessTokenCreated= "Access token created";
    }
}
