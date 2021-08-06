using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Template.Entities;

namespace WebApp.Template.UserCards
{
    public abstract class UserCardTemplate
    {
        protected AppUser appUser { get; set; }
        public void SetUser(AppUser user)
        {
            appUser = user;
        }
        public string Build()
        {
            if (appUser==null)
            {
                throw new ArgumentNullException(nameof(appUser));
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<div class='card' >");
            stringBuilder.Append(SetPicture());
            stringBuilder.Append($"  <div class='card - body'><h5>{appUser.UserName}</h5><p>{appUser.Description}</p>");

            stringBuilder.Append(SetFooter());
            stringBuilder.Append("</div/");
            stringBuilder.Append("</div/");

            return stringBuilder.ToString();
        }
        protected abstract string SetFooter();

        protected abstract string SetPicture();


    }
}
