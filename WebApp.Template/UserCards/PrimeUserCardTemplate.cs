using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Template.UserCards
{
    public class PrimeUserCardTemplate : UserCardTemplate
    {
        protected override string SetPicture()
        {
            return $"  <img src='{appUser.ImageAdress}' class='card - img - top''>";

            
        }
        protected override string SetFooter()
        {
            var sb = new StringBuilder();
            sb.Append("<a href='#' class='btn btn-primary'>Mesaj Gönder</a>");
            sb.Append("<a href='#' class='btn btn-primary'>Detaylı Profil</a>");
            return sb.ToString();
        }
    }
}
