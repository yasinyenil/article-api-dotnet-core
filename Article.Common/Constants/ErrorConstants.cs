using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Common.Constants
{
    public static class ErrorConstants
    {
        #region Database Error Messages

        public const string ArgumentNullExceptionMessageForDbContext = "DbContext objesi bos gecilemez!";
        public const string ArgumentNullExceptionMessageForDbContextTransaction = "Commit veya Rollback islemi yapilabilmesi icin Begin Transaction fonksiyonu ile Begin Transaction baslatilmasi gerekmektedir. Lutfen bir Begin Transaction islemi baslatiniz.";

        public const string ArgumentNullExceptionMessageForArticleContext = "Lutfen ulasmak istediginiz tabloya ait repository nesnesi icin tablonun bulundugu DatabaseContext nesnesini verin! Orn: ArticleContext";

        #endregion Database Error Messages

        #region Transaction Result Error Messages

        #region TableName

        #endregion TableName

        #endregion Transaction Result Error Messages

        #region General Error Messages

        public const string TransactionErrorMessage = "Yapilmak istenilen islem esnasinda bir hata olustu. Lutfen tekrar deneyin!";

        public const string ArgumentNullExceptionMessageForAttachItemToDbSet = "Yapmak istediginiz Insert - Update veya Delete islemi / islemleri icin islemin yapilacak oldugu typeof(T) tipindeki entity bos gecilemez. Lutfen yapmak istediginiz islem icin Entity nesnesini giriniz! ";

        #endregion
    }
}
