using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Common.Helpers
{
    public static class Tools
    {
        /// <summary>
        /// Geriye herhangi bir deger donmeyecek olan fonksiyonlar icin kullanilir
        /// </summary>
        /// <param name="action">Calistirilmasi istenilen action</param>
        /// <param name="catchAndDo">Action calisirken olusabilecek olan Exception icin yapilmak istenilen islemler</param>
        public static void TryCatch(this Action action, Func<Exception, bool> catchAndDo = null)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                var rethrow = catchAndDo?.Invoke(e) ?? true;
                if (rethrow)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Calismasi sonucunda geriye T tipinde deger dondurecek olan fonksiyonlar icin kullanilir
        /// </summary>
        /// <typeparam name="T">Geriye dondurulecek olan veri tipi</typeparam>
        /// <param name="function">Calistirilmasi istenilen fonksiyon</param>
        /// <param name="catchAndDo">Function calisirken olusabilecek olan Exception icin yapilmak istenilen islemler</param>
        /// <returns></returns>
        public static T TryCatch<T>(this Func<T> function, Func<Exception, bool> catchAndDo = null)
        {
            try
            {
                if (function != null)
                {
                    return function();
                }
            }
            catch (Exception e)
            {
                var rethrow = catchAndDo?.Invoke(e) ?? true;
                if (rethrow)
                {
                    throw;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Geriye herhangi bir deger donmeyecek olan fonksiyonlarda Try-Catch-Finally islemi yapmak istenilen fonksiyonlar icin kullanilir
        /// </summary>
        /// <param name="action">Calistirilmasi istenilen action</param>
        /// <param name="catchAndDo">Function calisirken olusabilecek olan Exception icin yapilmak istenilen islemler</param>
        /// <param name="finallyAndDo">Try - Catch icin Finally aninda yapilmasi istenilen islemler</param>
        public static void TryCatch(this Action action, Func<Exception, bool> catchAndDo = null, Action finallyAndDo = null)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                var rethrow = catchAndDo?.Invoke(e) ?? true;
                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                finallyAndDo?.Invoke();
            }
        }

        /// <summary>
        /// Calismasi sonucunda geriye T tipinde deger dondurecek olan fonksiyonlarda Try-Catch-Finally islemi yapmak istenilen fonksiyonlar icin kullanilir
        /// </summary>
        /// <typeparam name="T">Geriye dondurulecek olan veri tipi</typeparam>
        /// <param name="action">Calistirilmasi istenilen action</param>
        /// <param name="catchAndDo">Function calisirken olusabilecek olan Exception icin yapilmak istenilen islemler</param>
        /// <param name="finallyAndDo">Try - Catch icin Finally aninda yapilmasi istenilen islemler</param>
        /// <returns></returns>
        public static T TryCatch<T>(this Func<T> function, Func<Exception, bool> catchAndDo = null, Action finallyAndDo = null)
        {
            try
            {
                if (function != null)
                {
                    return function();
                }
            }
            catch (Exception e)
            {
                var rethrow = catchAndDo?.Invoke(e) ?? true;
                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                finallyAndDo?.Invoke();
            }
            return default(T);
        }

    }
}
