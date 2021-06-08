
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string UserNameAlreadyExists = "Kullanıcı adı seçilmiştir, lütfen farklı bir kullanıcı adı seçiniz.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryAdded = "Kategori eklendi.";
        public static string MarketAdded = "Market eklendi.";
        public static string MarketDeleted = "Market silindi.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string CountOfImageLimitError = "Fotoğraf sayısı fazla.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string AnswerNotTrue = "Cevabınız doğru değil.";
        public static string PasswordError = "Şifreniz hatalı.";
        public static string PasswordUpdated ="Şifreniz güncellendi.";
        public static string SuccessfulLogin = "Giriş başarılı.";
    }
}